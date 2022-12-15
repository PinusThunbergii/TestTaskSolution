namespace Parser
{
    public class CarDetailsGroup
    {
        public string Name { get; set; } = string.Empty;
        public int Group { get; set; }

        public override string ToString()
        {
            return $"{Name} {Group}";
        }
    }
}
