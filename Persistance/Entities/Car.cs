namespace Persistence.Entities
{
    public class Car
    {
        public long CarId { get; set; }
        public string ModelName { get; set; } = string.Empty;
        public string ModelCode { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CarComplectationsCodes { get; set; } = string.Empty;
        public ICollection<CarComplectation> CarComplectations { get; set; } = new List<CarComplectation>();
    }
}
