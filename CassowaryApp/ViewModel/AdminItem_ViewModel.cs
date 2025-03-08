using CassowaryApp.Data;
using CassowaryApp.Model;
using CassowaryApp.Pages;
using Microsoft.EntityFrameworkCore;

namespace CassowaryApp.ViewModel
{
    public class AdminItem_ViewModel
    {
        public List<Offer> items = new List<Offer>();
        public List<Offer> filteredItems = new List<Offer>();

        private readonly AppDbContext _context;

        public AdminItem_ViewModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            items = await _context.Offer.ToListAsync();
            foreach (var item in items)
            {
                if (item.Photo != null)
                {
                    item.Photo64 = Convert.ToBase64String(item.Photo);
                }
            }
            filteredItems = items;
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

        public byte[] LoadImageToByteArray(string imagePath)
        {
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagePath);
            return File.ReadAllBytes(fullPath);
        }

        public async Task deleteItem(int itemId)
        {
            var item = await _context.Offer.FindAsync(itemId);

            _context.Offer.Remove(item);
            await _context.SaveChangesAsync();

        }
    }
}
