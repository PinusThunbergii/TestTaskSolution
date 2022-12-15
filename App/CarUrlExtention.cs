using System.Text;
using Persistence;
using Persistence.Entities;
using Persistence.Entities.CarOptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Extentions
{
    public static class UrlExtention
    {
        public static string GetComplectationUrl(this Car car, string host, string vendor, string market)
        {
            var complectaionsUrl = new StringBuilder();
            complectaionsUrl.Append($"https://{host}/{vendor}/?function=getComplectations&market={market}&model={car.ModelCode}");
            if (car.EndDate != null)
            {
                complectaionsUrl.Append($"&startDate={car.StartDate.ToString("yyyyMMdd")}&endDate={car.EndDate?.ToString("yyyyMMdd")}");
            }
            else
            {
                complectaionsUrl.Append($"&startDate={car.StartDate.ToString("yyyyMMdd")}");
            }
            //$"https://{host}/{vendor}/?function=getComplectations&market={market}&model={car.ModelCode}&startDate={car.Start}&endDate={car.End}";
            return complectaionsUrl.ToString();
        }

        public static string GetDetailGroupUrl(this CarComplectation cc, string host, string vendor, string market)
        {
            var groupUrl = new StringBuilder();
            //?function=getGroups&market=EU&model=281220&modification=CV10L-UEMEXW&complectation=001
            groupUrl.Append($"https://{host}/{vendor}/?function=getGroups&market={market}&model={cc.Car.ModelCode}&modification={cc.CarCompectationCode}&complectation={cc.ComplectationNumber}");
            return groupUrl.ToString();
        }

        public static string GetDetailSubGroupUrl(this CarDetailGroup cdg, string host, string vendor, string market)
        {
            var subGrpoupUrl = new StringBuilder();
            //?function = getSubGroups & market = EU & model = 281220 & modification = CV10L - UEMEXW & group = 1
            subGrpoupUrl.Append($"https://{host}/{vendor}/?function=getSubGroups&market={market}&model={cdg.CarComplectation.Car.ModelCode}&modification={cdg.CarComplectation.CarCompectationCode}&group={cdg.Group}&complectation={cdg.CarComplectation.ComplectationNumber.ToString("D3")}");
            return subGrpoupUrl.ToString();
        }

        public static string GetDetailUrl(this CarDetailSubGroup cdsg, string host, string vendor, string market)
        {
            //?function=getParts&market=EU&model=281220&modification=CV10L-UEMEXW&group=1&subgroup=0901
            return $"https://{host}/{vendor}/?function=getParts&market={market}&model={cdsg.CarDetailGroup.CarComplectation.Car.ModelCode}&modification={cdsg.CarDetailGroup.CarComplectation.CarCompectationCode}&group={cdsg.CarDetailGroup.Group}&subgroup={cdsg.SubGroup.ToString("D4")}";
        }
    }
}