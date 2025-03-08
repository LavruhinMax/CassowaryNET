using CassowaryApp.Data;
using CassowaryApp.Model;
using CassowaryApp.Service;
using Microsoft.EntityFrameworkCore;

namespace CassowaryApp.ViewModel
{
    public class Tariff_ViewModel
    {
        public List<Tariff> tariffs = new List<Tariff>();
        public List<Exchange> exchanges = new List<Exchange>();
        public Tariff myTariff = new Tariff(), newTariff = new Tariff();
        public Exchange exchange = new Exchange();

        AppDbContext _context;

        public Tariff_ViewModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            tariffs = await _context.Tariff.ToListAsync();
            foreach (var tariff in tariffs)
            {
                if (tariff.Illustration != null)
                {
                    tariff.Illustration64 = Convert.ToBase64String(tariff.Illustration);
                }
            }
            exchanges = await _context.Exchange.ToListAsync();
            exchanges = exchanges.Where(e => e.CustomerID == UserContext.ID).ToList();
            myTariff = tariffs.FirstOrDefault(t => t.TariffID == UserContext.Tariff);
            exchange = exchanges.Last();
        }

        public async Task stopTariff()
        {
            var customer = await _context.Customer.FindAsync(UserContext.ID);

            customer.isPaused = UserContext.isPaused;
            await _context.SaveChangesAsync();
        }

        public async Task setNewTariff()
        {
            newTariff = tariffs.FirstOrDefault(t => t.TariffID == UserContext.Tariff);
            var customer = await _context.Customer.FindAsync(UserContext.ID);
            customer.TariffID = UserContext.Tariff;

            Exchange ex = new Exchange() { CustomerID = UserContext.ID, Date = DateTime.Today, previousTariff = myTariff.Name, newTariff = newTariff.Name };
            _context.Exchange.Add(ex);

            await _context.SaveChangesAsync();
            myTariff = newTariff;
        }
    }
}
