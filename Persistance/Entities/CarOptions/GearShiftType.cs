namespace Persistence.Entities.CarOptions
{
    public class GearShiftType
    {
        public long GearShiftTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CarComplectation> CarComplectations { get; set; } = new List<CarComplectation>();
        public override bool Equals(object? obj)
        {
            var gearShiftType = obj as GearShiftType;
            if (gearShiftType == null)
                return false;
            return Equals(gearShiftType);
        }

        public bool Equals(GearShiftType gearShiftType)
        {
            return this.Name == gearShiftType.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
