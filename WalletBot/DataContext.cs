using Microsoft.EntityFrameworkCore;
using WalletBot.Entities;

namespace WalletBot
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
    }
}
