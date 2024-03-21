using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace QuarterlySales.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
		[Required(ErrorMessage = "Quarter is required")]
		[Range(1, 4, ErrorMessage = "Quarter must be between 1 and 4")]
		public int Quarter { get; set; }
		[Required(ErrorMessage = "Year is required")]
		[Range(2001, int.MaxValue, ErrorMessage = "Year must be after the year 2000")]
		public int Year { get; set; }
		[Required(ErrorMessage = "Amount is required")]
		[Range(0, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
		public decimal? Amount { get; set; }
		[Required(ErrorMessage = "Employee is required")]
		public int EmployeeId { get; set; }
		[ValidateNever]
		public Employee? Employee { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			var sale = (Sale)validationContext.ObjectInstance;
			var salesContext = (SalesContext)validationContext.GetService(typeof(SalesContext));
			var existingSale = salesContext.Sales.FirstOrDefault(s =>
			s.Quarter == sale.Quarter &&
			s.Year == sale.Year &&
			s.EmployeeId == sale.EmployeeId &&
			s.SaleId != sale.SaleId);

			if(existingSale != null)
			{
				yield return new ValidationResult("Sales data with the same quarter, year, and employee already exists.", new[]{nameof(Quarter), nameof(Year), nameof(EmployeeId) });
			}
		}

		[UniqueSales(ErrorMessage = "Sales data with the same quarter, year, and employee already exists.")]
		public class UniqueSalesAttribute : ValidationAttribute
		{
			protected override ValidationResult IsValid(object value, ValidationContext validationContext)
			{
				var sale = (Sale)validationContext.ObjectInstance;
				var saleContext = (SalesContext)validationContext.GetService(typeof(SalesContext));
				var existingSale = saleContext.Sales.FirstOrDefault(s =>s.Quarter == sale.Quarter && s.Year == sale.Year && s.EmployeeId == sale.EmployeeId && s.SaleId != sale.SaleId);

				if (existingSale != null && existingSale.SaleId != sale.SaleId)
				{
					return new ValidationResult(ErrorMessage);
				}
				return ValidationResult.Success;
			}
		}
		
		public Sale UniqueSalesCheck => this;
	}
}
