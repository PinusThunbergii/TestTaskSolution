namespace Persistence.Entities.CarOptions
{
    public class Body
    {
        public long BodyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CarComplectation> CarComplectations { get; set; } = new List<CarComplectation>();

        public override bool Equals(object? obj)
        {
            var body = obj as Body;
            if (body == null)
                return false;
            return Equals(body);
        }

        public bool Equals(Body body)
        {
            return this.Name == body.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
