namespace QuarterlySales.Models
{
	public class SaleViewModel : Sale
	{
		public IEnumerable<Employee> Employees { get; set; }
		public IEnumerable<Sale> Sales { get; set; }
		public Employee Employee { get; set; }
		public Sale Sale { get; set; }
		public int Quarter { get; set; }
		public int Year { get; set; }
		public decimal Amount { get; set; }
		public int EmployeeId { get; set; }
		public int SaleId { get; set; }

		public SaleViewModel()
		{
			Employees = new List<Employee>();
			Sales = new List<Sale>();
		}
	}
<<<<<<< HEAD
}
=======
}
>>>>>>> 39d7a07e75018d3603d9f9a503825004aef1fdf2
