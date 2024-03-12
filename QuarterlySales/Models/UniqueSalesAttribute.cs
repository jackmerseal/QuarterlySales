using System.ComponentModel.DataAnnotations;

namespace QuarterlySales.Models
{
	public class UniqueSalesAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var sale = (Sale)validationContext.ObjectInstance;
			var dbContext = validationContext.GetService(typeof(SalesContext)) as SalesContext;

			if (dbContext.Sales.Any(s =>
				s.Quarter == sale.Quarter &&
				s.Year == sale.Year &&
				s.EmployeeId == sale.EmployeeId &&
				s.SaleId != sale.SaleId))
			{
				return new ValidationResult("Sales data with the same quarter, year, and employee already exists.");
			}

			return ValidationResult.Success!;
		}
	}
}
