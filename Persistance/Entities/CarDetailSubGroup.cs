namespace Persistence.Entities
{
    public class CarDetailSubGroup
    {
        public long CarDetailSubGroupId { get; set; }
        public int SubGroup { get; set; }
        public string Name { get; set; } = string.Empty;
        public CarDetailGroup CarDetailGroup { get; set; }
        public ICollection<CarDetail> CarDetails { get; set; } = new List<CarDetail>();
    }
}
