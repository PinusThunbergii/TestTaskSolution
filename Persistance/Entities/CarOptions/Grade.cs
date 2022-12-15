namespace Persistence.Entities.CarOptions
{
    public class Grade
    {
        public long GradeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CarComplectation> CarComplectations { get; set; } = new List<CarComplectation>();
        public override bool Equals(object? obj)
        {
            var grade = obj as Grade;
            if (grade == null)
                return false;
            return Equals(grade);
        }

        public bool Equals(Grade grade)
        {
            return this.Name == grade.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
