using Microsoft.EntityFrameworkCore;
namespace QuarterlySales.Models
{
    public class SalesContext : DbContext
    {
		public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;

		public SalesContext(DbContextOptions<SalesContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { EmployeeId = 1, Firstname = "Joanna", Lastname = "Walker", Birthdate = new DateTime(1966, 08, 26), Hiredate = new DateTime(1996, 01, 01), ManagerId = 0 },
                new Employee() { EmployeeId = 2, Firstname = "Peter", Lastname = "Griffin", Birthdate = new DateTime(1958, 07, 22), Hiredate = new DateTime(1999, 01, 31), }
                );

            modelBuilder.Entity<Sale>().HasData(
                new Sale() { SaleId = 1, Year = 2022, Quarter = 1, EmployeeId = 1, Amount = (decimal?)34567.00 },
                new Sale() { SaleId = 2, Year = 2021, Quarter = 1, EmployeeId = 1, Amount = (decimal?)37462.00 }
                );
        }
    }
}
