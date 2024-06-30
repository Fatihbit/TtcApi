namespace TtcApi.Models
{
    public class Product
    {
        public string ProductName { get; set; }
        public string UNNummer { get; set; }
        public string Gevaren { get; set; }
        public string Verpakkingsgroep { get; set; }

        public ICollection<Lading> Ladings { get; set; } = new List<Lading>();

    }
}
