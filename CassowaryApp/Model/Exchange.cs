namespace CassowaryApp.Model
{
    public class Exchange
    {
        public int ExchangeID { get; set; }
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public string? previousTariff { get; set; }
        public string newTariff { get; set; }
    }
}
