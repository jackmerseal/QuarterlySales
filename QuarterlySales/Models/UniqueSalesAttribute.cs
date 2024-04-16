using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using QuarterlySales.Models.DomainModels;

namespace QuarterlySales.Models
{
    public class UniqueSalesAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid( object value, ValidationContext validationContext )
		{
			var sale = (Sale)validationContext.ObjectInstance;
			var dbContext = (SalesContext)validationContext.GetService(typeof(SalesContext));

			var existingSale = dbContext.Sales
				.Where(s =>
					s.EmployeeId == sale.EmployeeId &&
					s.Year == sale.Year &&
					s.Quarter == sale.Quarter &&
					s.SaleId != sale.SaleId)
				.Join(dbContext.Employees, s => s.EmployeeId, e => e.EmployeeId, ( s, e ) => new { Sale = s, EmployeeName = e.Name })
				.FirstOrDefault();

			if (existingSale != null)
			{
				return new ValidationResult($"Sales for {existingSale.EmployeeName} for {sale.Year} Q{sale.Quarter} are already in the database");
			}

			return ValidationResult.Success;
		}
	}
}
