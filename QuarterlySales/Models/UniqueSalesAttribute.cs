using System.ComponentModel.DataAnnotations;
namespace QuarterlySales.Models
{
	public class UniqueSalesAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var sale = (Sale)validationContext.ObjectInstance;
			var salesContext = (SalesContext)validationContext.GetService(typeof(SalesContext));
			var existingSale = salesContext.Sales.FirstOrDefault(s => s.SaleId == sale.SaleId &&
																		 s.Quarter == sale.Quarter &&
																		 s.Year == sale.Year &&
																		 s.Amount == sale.Amount &&
																		 s.EmployeeId == sale.EmployeeId);

			if (existingSale != null)
			{
				return new ValidationResult($"Sales for {sale.Employee.Name} for {sale.Year} Q{sale.Quarter} are already in the database");
			}
			return ValidationResult.Success!;
		}
	}
}
