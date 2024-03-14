using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuarterlySales.Models;

namespace QuarterlySales.Controllers
{
    public class EmployeeController : Controller
    {
        private SalesContext _context;

        public EmployeeController(SalesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new EmployeeViewModel
            {
                Employees = _context.Employees.OrderBy(e => e.Firstname).ToList(),
                Sales = _context.Sales.Include(s => s.Employee).ToList()
            };
            return View(viewModel);
        }

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add Employee";
			return View("Add", new Employee());
		}
	}
}