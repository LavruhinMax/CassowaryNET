namespace CassowaryApp.Model
{
    public class Account
    {
        public int AccountID { get; set; }
        public int? AdminID { get; set; }
        public int? CustomerID { get; set; }
        public string Password { get; set; }
    }
}