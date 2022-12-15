namespace Persistence.Entities
{
    public class CarDetailGroup
    {
        public long CarDetailGroupId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Group { get; set; }
        public CarComplectation CarComplectation { get; set; }
        public ICollection<CarDetailSubGroup> CarDetailSubGroups { get; set; } = new List<CarDetailSubGroup>();
    }
}
