using Microsoft.EntityFrameworkCore;
using lab_1_2.Models; 

namespace lab_1_2
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Sale> Sales {  get; set; }
        public DbSet<SalesLog> SalesLogs { get; set; }
        public DbSet<SecurityLog> SecurityLogs { get; set; }
    }
}