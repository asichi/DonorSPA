using Microsoft.EntityFrameworkCore;

namespace DonorSPA.Data
{
    public class DonorDbContext : DbContext
    {
        public DbSet<DonationRecord> DonationRecords { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=sqlitedemo.db");
    }
}
