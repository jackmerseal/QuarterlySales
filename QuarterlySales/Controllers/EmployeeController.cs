using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
			var vm = new EmployeeViewModel();
			vm.Employees = _context.Employees.ToList();
			return View(vm);
		}

		[HttpPost]
		public IActionResult Add([FromForm] EmployeeViewModel vm)
		{
			if(vm.Employee != null)
			{
				vm.Employee = new Employee();
				if (ModelState.IsValid)
				{
					_context.Employees.Add(vm);
					_context.SaveChanges();
					return RedirectToAction("Index", "Home");
				}
			}
			vm.Employees = _context.Employees.ToList();
			return View(vm);
		}
	}
}