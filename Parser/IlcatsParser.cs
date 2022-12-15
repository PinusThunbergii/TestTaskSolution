using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System.ComponentModel;
using System.Text;
using System.Web;

namespace Parser
{
    public class IlcatsParser
    {
        public static async Task<IList<CarDetailsGroup>> ParseCarDetailsGroup(string content)
        {
            IConfiguration config = Configuration.Default;
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument document = await context.OpenAsync(req => req.Content(content));

            var rootDiv = document.QuerySelector("div.List ");
            if (rootDiv == null)
            {
                throw new NullReferenceException();
            }

            var carDetailsGroups = new List<CarDetailsGroup>();
            foreach (var listItem in rootDiv.Children)
            {

                var divName = listItem.Children.First();
                var a = (IHtmlAnchorElement)divName.Children.First();
                var name = a.TextContent;
                var href = a.Href;
                var queryKeyValue = HttpUtility.ParseQueryString(href.Substring(href.IndexOf('?')));
                var group = int.Parse(queryKeyValue["group"]);
                carDetailsGroups.Add(new() { Group = group, Name = name.Trim() });
            }

            return carDetailsGroups;
        }
        public static async Task<IList<CarDetailsSubGroup>> ParseCarDetailSubGroup(string content)
        {
            IConfiguration config = Configuration.Default;
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument document = await context.OpenAsync(req => req.Content(content));

            var rootDiv = document.QuerySelector("div.List ");
            var carDetailsSubGroups = new List<CarDetailsSubGroup>();

            foreach (var listElem in rootDiv.Children)
            {
                var divName = listElem.Children.Where(c => c.ClassName == "name").First();
                var a = (IHtmlAnchorElement)divName.Children.First();
                var name = a.TextContent;
                var href = a.Href;
                var queryKeyValue = HttpUtility.ParseQueryString(href.Substring(href.IndexOf('?')));
                var subGroup = int.Parse(queryKeyValue["subgroup"]);
                carDetailsSubGroups.Add(new()
                {
                    SubGroup = subGroup,
                    Name = name.Trim()
                });
            }

            return carDetailsSubGroups;
        }
        public static async Task<string> ParseCarDetailsGroupImageUrl(string content)
        {
            throw new NotImplementedException();
        }

        public static async Task<IList<CarDetail>> ParseCarDetails(string content)
        {
            IConfiguration config = Configuration.Default;
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument document = await context.OpenAsync(req => req.Content(content));

            var tbody = document.QuerySelector("table>tbody");
            if (tbody == null)
            {
                throw new NullReferenceException();
            }
            var trHeader = tbody.Children[0];
            var trDatas = tbody.Children.Except(new List<IElement> { trHeader }).ToList();

            var headersName = new List<string>();
            foreach (var th in trHeader.Children)
            {
                headersName.Add(th.TextContent);
            }
            var carDetails = new List<CarDetail>();
            for (int i = 0; i < trDatas.Count(); i++)
            {
                var checkElement = trDatas[i].Children.First();
                if (checkElement.TagName == "TH")
                {
                    var header = checkElement.TextContent;
                    //step forward 
                    i++;
                    for (; i < trDatas.Count(); i++)
                    {
                        var possibleData = trDatas[i].Children.First();
                        if (possibleData.TagName == "TD")
                        {
                            //if <tr> has <td> add all its childern
                            var dataElems = new List<IElement>();
                            dataElems.AddRange(trDatas[i].Children);
                            var dict = ExtractDetailData(dataElems);
                            carDetails.Add(CarDetail.CreateFromDictionary(dict, header));
                        }
                        else
                        {
                            //step back
                            i--;
                            break;
                        }
                    }
                    continue;
                }
            }
            return carDetails;
        }

        public static async Task<string> GetDetailImage(string content)
        {
            IConfiguration config = Configuration.Default;
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument document = await context.OpenAsync(req => req.Content(content));
            var divImage = document.QuerySelector("div.Image");
            var img = divImage.Children.First();
            var imageUrl = (img as IHtmlImageElement).Source;
            return imageUrl;
        }

        private static IDictionary<string, string> ExtractDetailData(IEnumerable<IElement> elements)
        {
            var data = new Dictionary<string, string>();
            foreach (var elem in elements)
            {
                var divs = elem.Children;
                foreach (var div in divs)
                {
                    switch (div.ClassName)
                    {
                        case "number":
                            var a = div.Children.First();
                            data.Add("number", a.TextContent);
                            break;
                        case "replaceNumber":
                            a = div.Children.First();
                            data.Add("replaceNumber", a.TextContent);
                            break;
                        case "count":
                            data.Add("count", div.TextContent);
                            break;
                        case "dateRange":
                            data.Add("dateRange", div.TextContent);
                            break;
                        case "usage":
                            data.Add("usage", div.TextContent);
                            break;
                    }
                }
            }
            return data;
        }

        public static async Task<IList<CarComplectaion>> ParseCarCopmlectations(string content)
        {
            IConfiguration config = Configuration.Default;
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument document = await context.OpenAsync(req => req.Content(content));

            var tbody = document.QuerySelector("table>tbody");
            var trHeader = tbody.Children[0];
            var trDatas = tbody.Children.Except(new List<IElement> { trHeader }).ToList();
            var headersName = new List<string>();
            foreach (var th in trHeader.Children)
            {
                headersName.Add(th.TextContent);
            }
            var carComplectations = new List<CarComplectaion>();
            var complectaionNumberCounter = 1;
            foreach (var tr in trDatas)
            {
                var tds = tr.Children;
                var rowValues = new List<string?>();

                //foreach (var td in tds)
                for (int i = 0; i < tds.Length; i++)
                {
                    var td = tds[i];
                    var div = td.Children.FirstOrDefault();
                    if (div == null)
                    {
                        rowValues.Add(null);
                    }
                    else if (div.ClassName == "modelCode")
                    {
                        rowValues.Add(div.Children[0].TextContent);
                    }
                    else
                    {
                        rowValues.Add(div.TextContent);
                    }
                }
                DateTime start;
                DateTime? end;
                CustomDataParser.ParseDateRange(rowValues[1], out start, out end);
                carComplectations.Add(new()
                {
                    ComplectationCode = rowValues[0],
                    ComplectationNumber = complectaionNumberCounter,
                    StartDate = start,
                    EndDate = end,
                    Engine1 = rowValues[2],
                    Body = rowValues[3],
                    Grade = rowValues[4],
                    Transmission = rowValues[5],
                    GearShiftType = rowValues[6],
                    DriversPosition = rowValues[7],
                    NoOfDoors = rowValues[8],
                    Destination1 = rowValues[9],
                    Destination2 = rowValues[10],
                });
                complectaionNumberCounter++;
            }
            return carComplectations;
        }

        public static async Task<IList<Car>> ParseCars(string content)
        {
            IConfiguration config = Configuration.Default;
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument document = await context.OpenAsync(req => req.Content(content));

            var listParent = document.QuerySelectorAll("div.Multilist").First();
            var listElemens = listParent.Children.Where(c => c.ClassName == "List").ToList();

            var cars = new List<Car>();

            foreach (var elem in listElemens)
            {
                var header = elem.Children.Where(c => c.ClassName == "Header").First();
                var name = header.Children.Where(c => c.ClassName == "name").First();
                var modelsList = elem.Children.Where(c => c.ClassName == "List ").First();
                var models = modelsList.Children.Where(c => c.ClassName == "List").ToList();
                foreach (var model in models)
                {
                    var idNode = model.Children.Where(c => c.ClassName == "id").First();
                    var dateRangeNode = model.Children.Where(c => c.ClassName == "dateRange").First();
                    var complectationCodesNode = model.Children.Where(c => c.ClassName == "modelCode").First();
                    var id = idNode.TextContent;
                    var href = idNode.Children.First().GetAttribute("href");
                    var dateRange = dateRangeNode.TextContent;
                    var complectationCodes = complectationCodesNode.TextContent;
                    var complectations = complectationCodes.Split(',');
                    DateTime start;
                    DateTime? end;
                    CustomDataParser.ParseDateRange(dateRange, out start, out end);

                    var car = new Car()
                    {
                        ModelCode = id,
                        ModelName = name.TextContent,
                        //Period = dateRange,
                        Complectations = complectations,
                        StartDate = start,
                        EndDate = end
                    };
                    cars.Add(car);
                }
            }
            return cars;
        }
    }
}
