namespace Persistence.Entities.CarOptions
{
    public class NoOfDoors 
    {
        public long NoOfDoorsId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CarComplectation> CarComplectations { get; set; } = new List<CarComplectation>();
        public override bool Equals(object? obj)
        {
            var noOfDoors = obj as NoOfDoors;
            if (noOfDoors == null)
                return false;
            return Equals(noOfDoors);
        }

        public bool Equals(NoOfDoors noOfDoors)
        {
            return this.Name == noOfDoors.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
