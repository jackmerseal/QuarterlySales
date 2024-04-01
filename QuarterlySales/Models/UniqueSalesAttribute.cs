using System;
using System.ComponentModel.DataAnnotations;
namespace QuarterlySales.Models
{
	public class UniqueSalesAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid( object value, ValidationContext validationContext )
		{
			var sale = (Sale)validationContext.ObjectInstance;
			var dbContext = (SalesContext)validationContext.GetService(typeof(SalesContext));
			var existingSale = dbContext.Sales
			.FirstOrDefault(s =>
					s.EmployeeId == sale.EmployeeId &&
					s.Year == sale.Year &&
					s.Quarter == sale.Quarter &&
					s.SaleId != sale.SaleId); 

			if (existingSale != null)
			{
				return new ValidationResult($"Sales for {sale.Employee?.Firstname} for {sale.Year} Q{sale.Quarter} are already in the database");
			}

			return ValidationResult.Success;
		}
	}
}