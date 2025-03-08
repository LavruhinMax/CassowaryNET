using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CassowaryApp.Model
{
    public class Tariff
    {
        public int TariffID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Content { get; set; }
        public byte[] Illustration { get; set; }

        [NotMapped]
        public string Illustration64 { get; set; }
    }
}
