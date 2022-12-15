namespace Parser
{
    public class CarComplectaion
    {
        public string ComplectationCode { get; set; } = string.Empty;
        public int ComplectationNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Engine1 { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Grade { get; set; } = string.Empty;
        public string Transmission { get; set; } = string.Empty;
        public string GearShiftType { get; set; } = string.Empty;
        public string DriversPosition { get; set; } = string.Empty;
        public string NoOfDoors { get; set; } = string.Empty;

        public string Destination1 { get; set; } = string.Empty;
        public string? Destination2 { get; set; }

        public override string ToString()
        {
            return $"{ComplectationCode} {StartDate.ToString("dd.MM.yyyy")} {EndDate?.ToString("dd.MM.yyyy")} {Engine1} {Body} {Grade} {Transmission} {GearShiftType} {DriversPosition} {NoOfDoors} {Destination1} {Destination2}";
        }
    }
}
