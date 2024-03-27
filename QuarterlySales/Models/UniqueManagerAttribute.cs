using System.ComponentModel.DataAnnotations;

namespace QuarterlySales.Models
{
	public class UniqueManagerAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var employee = (Employee)validationContext.ObjectInstance;
			var salesContext = (SalesContext)validationContext.GetService(typeof(SalesContext));
			var existingManager = salesContext.Employees.FirstOrDefault(e => e.EmployeeId == employee.ManagerId &&
																		 e.Firstname == employee.Firstname &&
																		 e.Lastname == employee.Lastname &&
																		 e.Birthdate == employee.Birthdate);

			if (existingManager != null)
			{
				return new ValidationResult("Manager and employee can't be the same person.");
			}
			return ValidationResult.Success!;
		}
	}
<<<<<<< HEAD
}
=======
}
>>>>>>> 39d7a07e75018d3603d9f9a503825004aef1fdf2
