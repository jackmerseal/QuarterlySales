using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using QuarterlySales.Models.DomainModels;
using QuarterlySales.Models.DataLayer.Configuration;
namespace QuarterlySales.Models
{
    public class SalesContext : IdentityDbContext<User>
    {
        public SalesContext( DbContextOptions<SalesContext> options ) : base(options) { }

        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ConfigureEmployees());
            modelBuilder.ApplyConfiguration(new ConfigureSales());
        }
    }
}
