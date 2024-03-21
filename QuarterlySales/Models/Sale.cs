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

		[UniqueSales(ErrorMessage = "Sales data with the same quarter, year, and employee already exists.")]
		public Sale UniqueSalesCheck => this;
	}
}
