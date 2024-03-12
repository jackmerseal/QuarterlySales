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
		[PastEarliestHireDateAttribute(ErrorMessage = "Date of hire must not be before 1/1/1995.")]
		public DateTime? Hiredate { get; set; }
        public int ManagerId { get; set; }
	}
}
