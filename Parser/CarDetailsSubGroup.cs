namespace Parser
{
    public class CarDetailsSubGroup
    {
        public int SubGroup { get; set; }
        public string Name { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{SubGroup} {Name}";
        }
    }
}
