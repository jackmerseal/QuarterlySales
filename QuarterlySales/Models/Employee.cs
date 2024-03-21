using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace QuarterlySales.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string Firstname { get; set; } = null!;
		[Required(ErrorMessage = "Last name is required.")]
		public string Lastname { get; set; } = null!;
		public string? Name => Firstname + ' ' + Lastname;
		[Required(ErrorMessage = "Birthdate is required.")]
		[PastDate(ErrorMessage = "Date of birth must be in the past.")]
		public DateTime? Birthdate { get; set; }
        [Required(ErrorMessage = "Hiredate is required.")]
		[PastDate(ErrorMessage = "Date of hire must be in the past.")]
		[PastEarliestHireDate(ErrorMessage = "Date of hire must not be before 1/1/1995.")]
		public DateTime? Hiredate { get; set; }
		[Required(ErrorMessage = "Manager is required.")]
		[UniqueManager(ErrorMessage = "Manager and employee can't be the same person.")]
        public int ManagerId { get; set; }

		[UniqueEmployee(ErrorMessage="Employee with that name and date of birth already exists in the database.")]
		public (string Firstname, string Lastname, DateTime Birthdate)? UniqueCheck => (Firstname, Lastname, Birthdate.GetValueOrDefault());

		public class PastEarliestHireDateAttribute : ValidationAttribute
		{
			public override bool IsValid(object value)
			{
				if (value is DateTime date)
				{
					return date >= new DateTime(1995, 1, 1);
				}
				return false;
			}
		}

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

			public class UniqueEmployeeAttribute : ValidationAttribute
			{
				if(value != null)
					{

					}
						return ValidationResult.Success!;
			}

			public class UniqueManagerAttribute : ValidationAttribute
			{
				protected override ValidationResult IsValid(object value, ValidationContext validationContext)
				{
					if(value != null)
					{

					}
						return ValidationResult.Success!;
				}
			}
		}

	}
}
