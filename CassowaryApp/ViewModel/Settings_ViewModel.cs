using CassowaryApp.Data;
using CassowaryApp.Model;
using CassowaryApp.Pages;
using CassowaryApp.Service;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Text.RegularExpressions;

namespace CassowaryApp.ViewModel
{
    public class Settings_ViewModel
    {
        public List<Exchange> exchanges = new List<Exchange>();
        public Exchange exchange = new Exchange();

        AppDbContext _context;
        public Settings_ViewModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            exchanges = await _context.Exchange.ToListAsync();
            exchanges = exchanges.Where(e => e.CustomerID == UserContext.ID).ToList();
            exchange = exchanges.First();
        }

        public async Task changePassword(string newPassword)
        {
            List<Account> accounts = new List<Account>();
            accounts = await _context.Account.ToListAsync();
            var account = accounts.FirstOrDefault(a => a.CustomerID == UserContext.ID);
            account.Password = Encryptor.Encrypt(newPassword);
            account.Password = newPassword;
            await _context.SaveChangesAsync();
        }

        public async Task updateMail(string mail)
        {
            UserContext.Email = mail;
            var customer = await _context.Customer.FindAsync(UserContext.ID);

            customer.Email = mail;
            await _context.SaveChangesAsync();
        }

        public async Task updatePhone(string phone)
        {
            UserContext.Phone = phone;
            var customer = await _context.Customer.FindAsync(UserContext.ID);

            customer.phoneNumber = phone;
            await _context.SaveChangesAsync();
        }
    }
}
