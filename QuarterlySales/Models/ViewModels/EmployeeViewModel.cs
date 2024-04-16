using QuarterlySales.Models.DomainModels;

namespace QuarterlySales.Models.ViewModels
{
    public class EmployeeViewModel : Employee
    {
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Sale> Sales { get; set; }
        public Employee Employee { get; set; }
        public Sale Sale { get; set; }
        public int EmployeeId { get; set; }
        public int SaleId { get; set; }
        public int SelectedEmployeeId { get; set; }

        public EmployeeViewModel()
        {
            Employees = new List<Employee>();
            Sales = new List<Sale>();
        }
    }
}