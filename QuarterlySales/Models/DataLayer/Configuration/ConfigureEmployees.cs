using QuarterlySales.Models.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace QuarterlySales.Models.DataLayer.Configuration
{
    public class ConfigureEmployees : IEntityTypeConfiguration<Employee>
    {
        public void Configure( EntityTypeBuilder<Employee> entity )
        {
            entity.HasData(
                new Employee() { EmployeeId = 1, Firstname = "Joanna", Lastname = "Walker", Birthdate = new DateTime(1966, 08, 26), Hiredate = new DateTime(1996, 01, 01), ManagerId = 0 },
                new Employee() { EmployeeId = 2, Firstname = "Peter", Lastname = "Griffin", Birthdate = new DateTime(1958, 07, 22), Hiredate = new DateTime(1999, 01, 31), }
                );
        }
    }
}
