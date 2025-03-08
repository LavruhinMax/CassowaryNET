namespace CassowaryApp.Model
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public int TariffID { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string Adress { get; set; }
        public string LSNumber { get; set; }
        public string Technology { get; set; }
        public string phoneNumber { get; set; }
        public string Email { get; set; }
        public int isPaused { get; set; }
    }
}
