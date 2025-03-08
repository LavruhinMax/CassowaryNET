using CassowaryApp.Data;
using CassowaryApp.Model;
using CassowaryApp.Pages;
using Microsoft.EntityFrameworkCore;

namespace CassowaryApp.ViewModel
{
    public class AdminAbonent_ViewModel
    {
        public List<Tariff> tariffs = new List<Tariff>();
        public List<Customer> abonents = new List<Customer>();
        public List<Customer> filteredAbonents = new List<Customer>();

        private readonly AppDbContext _context;

        public AdminAbonent_ViewModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            tariffs = await _context.Tariff.ToListAsync();
            abonents = await _context.Customer.ToListAsync();
            filteredAbonents = abonents;
        }

        public void Search(string searchOption)
        {
            if (string.IsNullOrEmpty(searchOption))
            {
                filteredAbonents = abonents;
            }
            else
            {
                filteredAbonents = abonents.Where(a => a.firstName.Contains(searchOption, StringComparison.OrdinalIgnoreCase) ||
                a.lastName.Contains(searchOption, StringComparison.OrdinalIgnoreCase) ||
                a.middleName.Contains(searchOption, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        public async Task deleteAbonent(int abonentId)
        {
            var customer = await _context.Customer.FindAsync(abonentId);
            var purchasesToDelete = await _context.Purchase.Where(p => p.CustomerID == abonentId).ToListAsync();
            var transactionsToDelete = await _context.Transaction.Where(t => t.CustomerID == abonentId).ToListAsync();
            var methodToDelete = _context.paymentMethod.FirstOrDefault(m => m.CustomerID == abonentId);

            if (purchasesToDelete.Any())
            {
                _context.Purchase.RemoveRange(purchasesToDelete);

                await _context.SaveChangesAsync();
            }

            if (transactionsToDelete.Any())
            {
                _context.Transaction.RemoveRange(transactionsToDelete);

                await _context.SaveChangesAsync();
            }

            if (methodToDelete != null)
            {
                _context.paymentMethod.Remove(methodToDelete);

                await _context.SaveChangesAsync();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            await refreshPage();
        }

        public async Task addAbonent(Customer ab)
        {
            _context.Customer.Add(ab);
            await _context.SaveChangesAsync();
            await refreshPage();
        }

        public async Task updateAbonent(Customer ab)
        {
            var customer = await _context.Customer.FindAsync(ab.CustomerID);

            customer.firstName = ab.firstName;
            customer.middleName = ab.middleName;
            customer.lastName = ab.lastName;
            customer.Adress = ab.Adress;
            customer.Technology = ab.Technology;
            customer.Email = ab.Email;
            customer.phoneNumber = ab.phoneNumber;

            await _context.SaveChangesAsync();
            await refreshPage();
        }

        public async Task refreshPage()
        {
            abonents = await _context.Customer.ToListAsync();
            filteredAbonents = abonents;
        }
    }
}
