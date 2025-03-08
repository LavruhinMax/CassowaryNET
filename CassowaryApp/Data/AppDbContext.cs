using Microsoft.EntityFrameworkCore;
using CassowaryApp.Model;

namespace CassowaryApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Account> Account { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<paymentMethod> paymentMethod { get; set; }
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Tariff> Tariff { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Exchange> Exchange { get; set; }
    }
}
