namespace TtcApi.Dtos
{
    public class StatusLadingDto
    {
        public int StatusLadingId { get; set; }
        public int LadingId { get; set; }
        public bool IsAccepted { get; set; }
        public string Reason { get; set; }
    }
}
