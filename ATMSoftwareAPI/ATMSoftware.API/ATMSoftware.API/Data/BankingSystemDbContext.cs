using ATMSoftware.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMSoftware.API.Data
{
    public class BankingSystemDbContext : DbContext
    {
        public BankingSystemDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CustomerData> CustomersData { get; set; }
        public DbSet<Transaction> TransactionRecord { get; set; }

    }
}
