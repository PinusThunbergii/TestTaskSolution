namespace Persistence.Entities.CarOptions
{
    public class Transmission
    {
        public long TransmissionId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<CarComplectation> CarComplectations { get; set; } = new List<CarComplectation>();

        public override bool Equals(object? obj)
        {
            var transmission = obj as Transmission;
            if (transmission == null)
                return false;
            return Equals(transmission);
        }

        public bool Equals(Transmission transmission)
        {
            return this.Name == transmission.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
