using System.ComponentModel.DataAnnotations;

namespace QuarterlySales.Models
{
	public class UniqueManagerAttribute : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
		{
			if()
			return ValidationResult.Success!;
		}
	}
}
