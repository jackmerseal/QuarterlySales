using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace QuarterlySales.Models
{
	public class PastDateAttribute : ValidationAttribute, IClientModelValidator
	{
		public void AddValidation(ClientModelValidationContext ctx)
		{
			if (!ctx.Attributes.ContainsKey("data-val"))
			{
				ctx.Attributes.Add("data-val", "true");
			}
			ctx.Attributes.Add("data-val-pastdate", "Date must be in the past");
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				if ((System.DateTime)value < DateTime.Now)
				{
					return ValidationResult.Success!;
				}
				else
				{
					return new ValidationResult("Date must be in the past");
				}
			}
			else
			{
				return new ValidationResult("Date is required");
			}
		}
	}
}
