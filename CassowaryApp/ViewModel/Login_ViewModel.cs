using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using CassowaryApp.Data;
using CassowaryApp.Model;
using CassowaryApp.Pages;
using CassowaryApp.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CassowaryApp.ViewModel
{
    public class Login_ViewModel
    {
        public List<Account> accounts = new List<Account>();
        public List<Admin> admins = new List<Admin>();
        public List<Customer> abonents = new List<Customer>();

        private readonly AppDbContext _context;

        public Login_ViewModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task InitializeAsync()
        {
            accounts = await _context.Account.ToListAsync();
            admins = await _context.Admin.ToListAsync();
            abonents = await _context.Customer.ToListAsync();
        }

        public bool check(string login, string password, bool mode)
        {
            foreach (var account in accounts)
            {
                foreach (var admin in admins)
                    if (account.AdminID == admin.AdminID && login == admin.Email && password == Encryptor.Decrypt(account.Password))
                    {
                        contextSetter(admin.AdminID, login, password, "Админ", admin.firstName, admin.lastName, admin.phoneNumber, admin.Email);
                        return true;
                    }
            }
            foreach (var account in accounts)
            {
                foreach (var abonent in abonents)
                {
                    if (mode)
                    {
                        if (account.CustomerID == abonent.CustomerID && login == abonent.Email && password == Encryptor.Decrypt(account.Password))
                        {
                            contextSetter(abonent.CustomerID, login, password, "Абонент", abonent.firstName, abonent.lastName, abonent.phoneNumber, abonent.Email);
                            UserContext.Adress = abonent.Adress;
                            UserContext.Tariff = abonent.TariffID;
                            UserContext.Technology = abonent.Technology;
                            UserContext.LSnumber = abonent.LSNumber;
                            UserContext.isPaused = abonent.isPaused;
                            return true;
                        }
                    }
                    else
                    {
                        if (account.CustomerID == abonent.CustomerID && login == abonent.LSNumber && password == Encryptor.Decrypt(account.Password))
                        {
                            contextSetter(abonent.CustomerID, login, password, "Абонент", abonent.firstName, abonent.lastName, abonent.phoneNumber, abonent.Email);
                            UserContext.Adress = abonent.Adress;
                            UserContext.Tariff = abonent.TariffID;
                            UserContext.Technology = abonent.Technology;
                            UserContext.LSnumber = abonent.LSNumber;
                            UserContext.isPaused = abonent.isPaused;
                            return true;
                        }
                    }
                }
            }
            return false;          
        }

        private void contextSetter(int ID, string login, string password, string status, string name, string lastName, string phone, string email)
        {
            UserContext.ID = ID;
            UserContext.Login = login;
            UserContext.Password = password;
            UserContext.Status = status;
            UserContext.Name = name;
            UserContext.lastName = lastName;
            UserContext.Phone = phone;
            UserContext.Email = email;
        }

        public void setRandomUserContext()
        {
            if (!(abonents == null && abonents.Count == 0 && accounts == null && accounts.Count == 0))
            {
                Customer randAbonent = new Customer();
                Account account = new Account();
                Random random = new Random();
                int randomIndex = random.Next(0, abonents.Count);

                randAbonent = abonents[randomIndex];
                account = accounts.FirstOrDefault(a => a.CustomerID == randAbonent.CustomerID);
                contextSetter(randAbonent.CustomerID, randAbonent.Email, Encryptor.Decrypt(account.Password), "Абонент", randAbonent.firstName, randAbonent.lastName, randAbonent.phoneNumber, randAbonent.Email);
                UserContext.Adress = randAbonent.Adress;
                UserContext.Tariff = randAbonent.TariffID;
                UserContext.Technology = randAbonent.Technology;
                UserContext.LSnumber = randAbonent.LSNumber;
                UserContext.isPaused = randAbonent.isPaused;
            }

        }
    }
}
