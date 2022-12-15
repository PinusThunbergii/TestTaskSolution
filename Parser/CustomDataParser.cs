namespace Parser
{
    public static class CustomDataParser
    {
        //08.2016 -    ...   
        //07.2014 -    ...   
        //07.2011 - 07.2014
        //01.04.2010 -      ...     
        public static void ParseDateRange(string raw, out DateTime start, out DateTime? end)
        {
            var splited = raw.Split('-');
            var rawStart = splited[0].Trim();
            var rawEnd = splited[1].Trim();
            start = ParseDate(rawStart) ?? throw new ArgumentException("Invalid date format");
            end = ParseDate(rawEnd);
        }

        public static DateTime? ParseDate(string raw)
        {
            DateTime? date;
            if (raw == "...")
            {
                return null;
            }

            if (raw.Length == 7)
            {
                date = DateTime.ParseExact(raw, "MM.yyyy", null);
            }
            else if (raw.Length == 10)
            {
                date = DateTime.ParseExact(raw, "dd.MM.yyyy", null);
            }
            else
            {
                throw new ArgumentException("Invalid date format");
            }
            return date;
        }
    }
}
