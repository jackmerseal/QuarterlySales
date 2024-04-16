using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace QuarterlySales.Models.DomainModels
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

        public class PastDateAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null && (DateTime)value < DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Date must be in the past.");
            }
        }

        public class UniqueEmployeeAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
            {
                var employee = (Employee)validationContext.ObjectInstance;
                var salesContext = (SalesContext)validationContext.GetService(typeof(SalesContext));
                var existingEmployee = salesContext.Employees.FirstOrDefault(e => e.Firstname == employee.Firstname &&
                                                                             e.Lastname == employee.Lastname &&
                                                                             e.Birthdate == employee.Birthdate);

                if (existingEmployee != null && existingEmployee.EmployeeId != employee.EmployeeId)
                {
                    return new ValidationResult($"{employee.Firstname} {employee.Lastname} (DOB: {employee.Birthdate} is already in the database.");
                }
                return ValidationResult.Success!;
            }
        }

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
    }
}