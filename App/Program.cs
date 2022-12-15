using App.Extentions;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Entities;
using Persistence.Entities.CarOptions;
using System.Net;
using System.Web;


var dbContextOptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
dbContextOptionsBuilder.UseSqlServer("Server=localhost,1433;Database=TestTaskDb;User Id=SA;Password=1234567890Qwerty@;MultipleActiveResultSets=True;TrustServerCertificate=True");

var dbContext = new DatabaseContext(dbContextOptionsBuilder.Options);
var vendor = "toyota";
var market = "EU";
var host = "www.ilcats.ru";
var carUrl = $"https://{host}/{vendor}/?function=getModels&market={market}";

Console.OutputEncoding = System.Text.Encoding.UTF8;

try
{
    var cars = await LoadCars(carUrl, dbContext);
    //will parse only one car because site doesn't have uniform data structure 
    foreach (var car in cars.Where(c => c.ModelCode == "281220").ToList())
    {
        var complectationUrl = car.GetComplectationUrl(host, vendor, market);
        var complectations = await LoadComplectations(car, complectationUrl, dbContext);
        //take one complectation 
        foreach (var complectation in complectations.Take(1))
        {
            var groupUrl = complectation.GetDetailGroupUrl(host, vendor, market);
            var groups = await LoadDetailGroups(complectation, groupUrl, dbContext);

            foreach(var group in groups)
            {
                var subGroupUrl = group.GetDetailSubGroupUrl(host, vendor, market);
                var subGroups = await LoadDetailSubGroup(group, subGroupUrl, dbContext);

                foreach(var subGroup in subGroups)
                {
                    var detailUrl = subGroup.GetDetailUrl(host, vendor, market);
                    var details = await LoadDetail(subGroup, detailUrl, dbContext);
                }
            }
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    Console.ReadKey();
}

async Task<IList<Car>> LoadCars(string carUrl, DatabaseContext dbContext)
{
    var content = await Networking.Helpers.GetContent(carUrl, Networking.Helpers.AddFireFoxHeader);
    var cars = await Parser.IlcatsParser.ParseCars(content);
    var pcars = cars.Select(car => new Car()
    {
        ModelCode = car.ModelCode,
        ModelName = car.ModelName,
        StartDate = car.StartDate,
        EndDate = car.EndDate,
        CarComplectationsCodes = string.Join(",", car.Complectations)
    }).ToList();
    await dbContext.AddRangeAsync(pcars);
    await dbContext.SaveChangesAsync();
    return pcars;
}

async Task<IList<CarComplectation>> LoadComplectations(Car pcar, string complectationUrl, DatabaseContext dbContext)
{
    var content = await Networking.Helpers.GetContent(complectationUrl, Networking.Helpers.AddFireFoxHeader);
    var complectations = await Parser.IlcatsParser.ParseCarCopmlectations(content);
    var pcomplectations = complectations.Select(cc => CreateCarComplectation(cc, pcar, dbContext)).ToList();
    await dbContext.AddRangeAsync(pcomplectations);
    await dbContext.SaveChangesAsync();
    return pcomplectations;
}

async Task<IList<CarDetailGroup>> LoadDetailGroups(CarComplectation pcomplectation, string groupUrl, DatabaseContext dbContext)
{
    var content = await Networking.Helpers.GetContent(groupUrl, Networking.Helpers.AddFireFoxHeader);
    var groups = await Parser.IlcatsParser.ParseCarDetailsGroup(content);
    var pgroups = groups.Select(g => new CarDetailGroup
    {
        Name = g.Name,
        Group = g.Group,
        CarComplectation = pcomplectation
    }).ToList();
    await dbContext.AddRangeAsync(pgroups);
    await dbContext.SaveChangesAsync();
    return pgroups;
}

async Task<IList<CarDetailSubGroup>> LoadDetailSubGroup(CarDetailGroup pdetailGroup, string subGroupUrl, DatabaseContext dbContext)
{
    var content = await Networking.Helpers.GetContent(subGroupUrl, Networking.Helpers.AddFireFoxHeader);
    var subGroups = await Parser.IlcatsParser.ParseCarDetailSubGroup(content);
    var psubGroups = subGroups.Select(sg => new CarDetailSubGroup()
    {
        Name = sg.Name,
        SubGroup = sg.SubGroup,
        CarDetailGroup = pdetailGroup
    }).ToList();
    await dbContext.AddRangeAsync(psubGroups);
    await dbContext.SaveChangesAsync();
    return psubGroups;
}

async Task<IList<CarDetail>> LoadDetail(CarDetailSubGroup pdetailSubGroup, string detailUrl, DatabaseContext dbContext)
{
    var content = await Networking.Helpers.GetContent(detailUrl, Networking.Helpers.AddFireFoxHeader);
    var details = await Parser.IlcatsParser.ParseCarDetails(content);
    var imageUrl = await Parser.IlcatsParser.GetDetailImage(content);
    var imageGenName = DownloadDetailImage(imageUrl);
    var pdetails = details.Select(d => new CarDetail()
    {
        CarDetailSubGroup = pdetailSubGroup,
        CarDetailCode = d.CarDetailCode,
        TreeCode = d.TreeCode,
        TreeName = d.TreeName,
        Count = d.Count,
        ReplacmentCode = d.ReplacmentCode,
        Info = d.Info,
        StartDate = d.StartDate,
        EndDate = d.EndDate,
        ImageGUID = imageGenName,
    }).ToList();
    await dbContext.AddRangeAsync(pdetails);
    await dbContext.SaveChangesAsync();
    return pdetails;
}

CarComplectation CreateCarComplectation(Parser.CarComplectaion cc, Persistence.Entities.Car c, DatabaseContext context)
{
    var p_cc = new CarComplectation();
    p_cc.Car = c;
    p_cc.StartDate = cc.StartDate;
    p_cc.EndDate = cc.EndDate;
    p_cc.CarCompectationCode = cc.ComplectationCode;
    p_cc.ComplectationNumber = cc.ComplectationNumber;
    p_cc.Engine1 = TryAddOrGetExists(new Engine() { Name = cc.Engine1 }, context.Engines, dbContext);
    p_cc.Body = TryAddOrGetExists(new Body() { Name = cc.Body }, context.Bodies, dbContext);
    p_cc.Grade = TryAddOrGetExists(new Grade() { Name = cc.Grade }, context.Grades, dbContext);
    p_cc.Transmission = TryAddOrGetExists(new Transmission() { Name = cc.Transmission }, context.Transmissions, dbContext);
    p_cc.GearShiftType = TryAddOrGetExists(new GearShiftType() { Name = cc.GearShiftType }, context.GearShiftTypes, dbContext);
    p_cc.DriversPosition = TryAddOrGetExists(new DriversPosition() { Name = cc.DriversPosition }, context.DriversPositions, dbContext);
    p_cc.NoOfDoors = TryAddOrGetExists(new NoOfDoors() { Name = cc.NoOfDoors }, context.NoOfDoors, dbContext);
    p_cc.Destination1 = TryAddOrGetExists(new Destination() { Name = cc.Destination1 }, context.Destinations, dbContext);
    if (string.IsNullOrEmpty(cc.Destination2))
    {
        p_cc.Destination2 = null;
    }
    else
    {
        p_cc.Destination2 = TryAddOrGetExists(new Destination() { Name = cc.Destination2 }, context.Destinations, dbContext);
    }
    return p_cc;
}

T TryAddOrGetExists<T>(T t, DbSet<T> dbSet, DbContext dbContext) where T : class
{

    //get object that value equal to that we try to add, if exists
    var tFromSet = dbSet.ToList().Where(x => x.Equals(t)).FirstOrDefault();
    if (tFromSet == null)
    {
        dbSet.Add(t);
        dbContext.SaveChanges();
        return t;
    }
    else
    {
        return tFromSet;
    }
}

string DownloadDetailImage(string imageUrl)
{
    var queryArgs = HttpUtility.ParseQueryString(imageUrl);
    var filename = queryArgs["filename"];
    var extention = filename.Substring(filename.IndexOf("."));

    var generatedName = Guid.NewGuid().ToString();

    using (var webClient = new WebClient())
    {
        webClient.DownloadFile(imageUrl, $"../../../images/{generatedName}{extention}");
    }
    return generatedName;
}