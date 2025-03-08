using CassowaryApp.Data;
using CassowaryApp.Model;
using CassowaryApp.Service;
using Microsoft.EntityFrameworkCore;

namespace CassowaryApp.ViewModel
{
    
    public class Equip_ViewModel
    {
        public int examples = 0;
        public List<Offer> items = new List<Offer>();
        public List<Offer> filteredItems = new List<Offer>();
        public List<paymentMethod> methods = new List<paymentMethod>();
        public paymentMethod myMethod = new paymentMethod();

        private readonly AppDbContext _context;
        public Equip_ViewModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            items = await _context.Offer.ToListAsync();
            filteredItems = items;
            foreach (var item in items)
            {
                examples++;
                if (item.Photo != null)
                {
                    item.Photo64 = Convert.ToBase64String(item.Photo);
                }
            }
            methods = await _context.paymentMethod.ToListAsync();
            myMethod = methods.FirstOrDefault(m => m.CustomerID == UserContext.ID);
        }

        public void Search(string searchOption)
        {
            if (string.IsNullOrEmpty(searchOption))
            {
                filteredItems = items;
            }
            else
            {
                filteredItems = items.Where(i => i.itemName.Contains(searchOption, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        public async Task addPurchase(Purchase pur)
        {
            _context.Add(pur);
            await _context.SaveChangesAsync();
        }

        public async Task addTransaction(Transaction tr)
        {
            _context.Transaction.Add(tr);
            await _context.SaveChangesAsync();
        }
    }
}
