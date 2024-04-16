using QuarterlySales.Models.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace QuarterlySales.Models.DataLayer.Configuration
{
    public class ConfigureSales : IEntityTypeConfiguration<Sale>
    {
        public void Configure( EntityTypeBuilder<Sale> entity )
        {
            entity.HasData(
                new Sale() { SaleId = 1, Year = 2022, Quarter = 1, EmployeeId = 1, Amount = (decimal?)34567.00 },
                new Sale() { SaleId = 2, Year = 2021, Quarter = 1, EmployeeId = 1, Amount = (decimal?)37462.00 }
                );
        }
    }
}