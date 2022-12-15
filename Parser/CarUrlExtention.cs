using System.Text;

namespace Parser
{
    public static class CarUrlExtention
    {
        public static string GetComplectationUrl(this Car car, string vendor, string market)
        {
            var host = "www.ilcats.ru";
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
    }
}