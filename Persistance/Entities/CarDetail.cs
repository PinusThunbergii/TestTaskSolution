namespace Persistence.Entities
{
    public class CarDetail
    {
        public long CarDetailId { get; set; }
        public CarDetailSubGroup CarDetailSubGroup { get; set; }
        public string CarDetailCode { get; set; } = string.Empty;
        public int Count { get; set; }
        public string Info { get; set; } = string.Empty;
        public string TreeCode { get; set; } = string.Empty;
        public string TreeName { get; set; } = string.Empty;
        public string? ReplacmentCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string ImageGUID { get; set; } = string.Empty;
    }
}
