namespace Persistence.Entities.CarOptions
{
    public class Destination
    {
        public long DestinationId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CarComplectation> CarComplectations1 { get; set; } = new List<CarComplectation>();
        public ICollection<CarComplectation> CarComplectations2 { get; set; } = new List<CarComplectation>();
        public override bool Equals(object? obj)
        {
            var body = obj as Destination;
            if (body == null)
                return false;
            return Equals(body);
        }

        public bool Equals(Destination destination)
        {
            return this.Name == destination.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
