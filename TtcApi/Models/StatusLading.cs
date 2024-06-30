namespace TtcApi.Models
{
    public class StatusLading
    {
        public int StatusLadingId { get; set; } // Primary Key
        public int LadingId { get; set; } // Foreign Key
        public bool? IsAccepted { get; set; }
        public string? Reason { get; set; } // Reden voor acceptatie of afwijzing

        // Navigation properties
        public Lading Lading { get; set; }
    }
}
