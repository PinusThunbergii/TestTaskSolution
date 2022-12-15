using Humanizer;

namespace Parser
{
    public class CarDetail
    {
        public string CarDetailCode { get; set; } = string.Empty;
        public int Count { get; set; }
        public string Info { get; set; } = string.Empty;
        public string TreeCode { get; set; } = string.Empty;
        public string TreeName { get; set; } = string.Empty;
        public string? ReplacmentCode { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public static CarDetail CreateFromDictionary(IDictionary<string, string> dict, string header = "")
        {
            DateTime start;
            DateTime? end;
            CustomDataParser.ParseDateRange(dict["dateRange"], out start, out end);
            string? rc = null;
            dict.TryGetValue("replaceNumber", out rc);
            var count = 0;
            var res = int.TryParse(dict["count"], out count);
            //header has weird symbol :-(
            header = header.Replace('\x00A0', ' ');
            var treeCode = header.Substring(0, header.IndexOf(' ')).Trim();
            var treeName = header.Substring(header.IndexOf(' ')).Trim();
            var cd = new CarDetail()
            {
                CarDetailCode = dict["number"],
                //Count = int.Parse(dict["count"]),
                Count = res ? count: dict["count"].FromRoman(),
                ReplacmentCode = rc,
                Info = dict["usage"],
                StartDate = start,
                EndDate = end,
                TreeCode = treeCode,
                TreeName = treeName
            };
            return cd;
        }

        public override string ToString()
        {
            return $"{CarDetailCode} {Count} {Info} {StartDate.ToString("dd.MM.yyyy")} {EndDate?.ToString("dd.MM.yyyy")} {TreeCode} {ReplacmentCode}";
        }
    }
}
