using CassowaryApp.Data;
using CassowaryApp.Model;
using CassowaryApp.Service;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection.Metadata.Ecma335;

namespace CassowaryApp.ViewModel
{
    public class Main_ViewModel
    {
        public List<Purchase> purchases = new List<Purchase>();
        public List<Transaction> transactions = new List<Transaction>();
        public List<Tariff> tariffs = new List<Tariff>();
        public List<paymentMethod> methods = new List<paymentMethod>();
        public List<Exchange> exchanges = new List<Exchange>();
        public paymentMethod myMethod = new paymentMethod();
        public Tariff myTariff = new Tariff();

        public DateTime paymentDate;
        AppDbContext _context;

        public Main_ViewModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            purchases = await _context.Purchase.ToListAsync();
            transactions = await _context.Transaction.ToListAsync();
            tariffs = await _context.Tariff.ToListAsync();
            methods = await _context.paymentMethod.ToListAsync();
            exchanges = await _context.Exchange.ToListAsync();

            transactions = transactions.Where(t => t.CustomerID == UserContext.ID).ToList();
            purchases = purchases.Where(p => p.CustomerID == UserContext.ID).ToList();
            methods = methods.Where(m => m.CustomerID == UserContext.ID).ToList();
            exchanges = exchanges.Where(e => e.CustomerID == UserContext.ID).ToList();
            myTariff = tariffs.First(t => t.TariffID == UserContext.Tariff);
            myMethod = methods.First(m => m.CustomerID == UserContext.ID);

            DateTime connectionDate = exchanges.First().Date;
            DateTime today = DateTime.Today;

            if (today.Day >= connectionDate.Day) paymentDate = new DateTime(today.Year, today.Month, connectionDate.Day).AddMonths(1);
            else paymentDate = new DateTime(today.Year, today.Month, connectionDate.Day);
        }

        public async Task updatePayment(paymentMethod payment)
        {
            var meth = await _context.paymentMethod.FindAsync(UserContext.ID);
            meth.Method = payment.Method;
            meth.Requisites = payment.Requisites;
            await _context.SaveChangesAsync();
        }

    }
}