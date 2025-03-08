namespace CassowaryApp.Model
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int CustomerID { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }
        public decimal Amount { get; set; }
    }
}
