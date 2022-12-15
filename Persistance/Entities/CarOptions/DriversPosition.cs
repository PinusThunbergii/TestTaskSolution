namespace Persistence.Entities.CarOptions
{
    public class DriversPosition
    {
        public long DriversPositionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CarComplectation> CarComplectations { get; set; } = new List<CarComplectation>();
        public override bool Equals(object? obj)
        {
            var driverPosition = obj as DriversPosition;
            if (driverPosition == null)
                return false;
            return Equals(driverPosition);
        }

        public bool Equals(DriversPosition driverPosition)
        {
            return this.Name == driverPosition.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
