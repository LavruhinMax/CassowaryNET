namespace CassowaryApp.Model
{
    public class paymentMethod
    {
        public int paymentMethodID { get; set; }
        public int CustomerID { get; set; }
        public string Method { get; set; }
        public string? Requisites { get; set; }
    }
}
