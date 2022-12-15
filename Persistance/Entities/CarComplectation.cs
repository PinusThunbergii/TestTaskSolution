using Persistence.Entities;
using Persistence.Entities.CarOptions;

namespace Persistence
{
    public class CarComplectation
    {
        public long CarComplectationId { get; set; }
        public string CarCompectationCode { get; set; } = string.Empty;
        public int ComplectationNumber { get; set; }
        public Car Car { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Engine Engine1 { get; set; }
        public Body Body{ get; set; }
        public Grade Grade { get; set; }
        public Transmission Transmission { get; set; }
        public GearShiftType GearShiftType { get; set; }
        public DriversPosition DriversPosition { get; set; }
        public NoOfDoors NoOfDoors { get; set; }
        public Destination? Destination1 { get; set; }
        public Destination? Destination2 { get; set; }
        public ICollection<CarDetailGroup> CarDetailGroups { get; set; } = new List<CarDetailGroup>();
    }
}
