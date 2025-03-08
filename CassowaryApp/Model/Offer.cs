using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CassowaryApp.Model
{
    public class Offer
    {
        public int OfferID { get; set; }
        public string itemName { get; set; }
        public string itemType { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public byte[] Photo { get; set; }

        [NotMapped]
        public string Photo64 { get; set; }
    }
}
