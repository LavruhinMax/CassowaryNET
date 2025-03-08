using CassowaryApp.Data;
using CassowaryApp.Model;
using CassowaryApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace CassowaryApp.ViewModel
{
    public class AdminTariff_ViewModel
    {
        public List<Tariff> tariffs = new List<Tariff>();
        public List<Tariff> filteredTariffs = new List<Tariff>();

        private readonly AppDbContext _context;

        public AdminTariff_ViewModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            tariffs = await _context.Tariff.ToListAsync();
            filteredTariffs = tariffs;
            foreach (var tariff in tariffs)
            {
                if (tariff.Illustration != null)
                {
                    tariff.Illustration64 = Convert.ToBase64String(tariff.Illustration);
                }
            }
        }

        public void Search(string searchOption)
        {
            if (string.IsNullOrEmpty(searchOption))
            {
                filteredTariffs = tariffs;
            }
            else
            {
                filteredTariffs = tariffs.Where(t => t.Name.Contains(searchOption, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        public async Task addTariff(Tariff tr)
        {
            _context.Tariff.Add(tr);
            await _context.SaveChangesAsync();
            await refreshPage();
        }

        public async Task updateTariff(Tariff tr)
        {
            var tariff = await _context.Tariff.FindAsync(tr.TariffID);

            tariff.Name = tr.Name;
            tariff.Price = tr.Price;
            tariff.Content = tr.Content;
            tariff.Illustration = tr.Illustration;

            await _context.SaveChangesAsync();
            await refreshPage();
        }

        public async Task deleteTariff(int tariffId)
        {
            var customers = await _context.Customer.ToListAsync();
            if(customers != null)
            {
                var filteredCustomers = customers.Where(c => c.TariffID == tariffId).ToList();
                foreach(var fc in filteredCustomers)
                {
                    var customer = await _context.Customer.FindAsync(fc.CustomerID);
                    if(customer != null) customer.TariffID = 1;
                }
            }
            var tariff = await _context.Tariff.FindAsync(tariffId);

            _context.Tariff.Remove(tariff);
            await _context.SaveChangesAsync();
            await refreshPage();
        }

        public async Task refreshPage()
        {
            tariffs = await _context.Tariff.ToListAsync();
            filteredTariffs = tariffs;
        }
    }
}
