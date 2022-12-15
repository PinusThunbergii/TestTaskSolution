namespace Persistence.Entities.CarOptions
{
    public class Engine
    {
        public long EngineId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CarComplectation> CarComplectations { get; set; } = new List<CarComplectation>();

        public override bool Equals(object? obj)
        {
            var engine = obj as Engine;
            if (engine == null)
                return false;
            return Equals(engine);
        }

        public bool Equals(Engine engine)
        {
            return this.Name == engine.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
