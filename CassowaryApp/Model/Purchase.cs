namespace CassowaryApp.Model
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int CustomerID { get; set; }
        public int? OfferID { get; set; }
        public string itemName { get; set; }
        public string itemType { get; set; }
        public string purchaseMethod { get; set; }
        public DateTime purchaseDate { get; set; }
    }
}
