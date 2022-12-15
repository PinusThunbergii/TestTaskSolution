namespace Parser
{
    public class Car
    {
        public string ModelName { get; set; } = string.Empty;
        public string ModelCode { get; set; } = string.Empty;
        //public string Period { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public IEnumerable<string> Complectations { get; set; } = Enumerable.Empty<string>();

        public override string ToString()
        {
            return $"{ModelName} {ModelCode} {StartDate.ToString("dd.MM.yyyy")} {EndDate?.ToString("dd.MM.yyyy")} {string.Join("|", Complectations)}";
        }
    }

}