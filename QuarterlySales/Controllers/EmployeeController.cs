using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
		public IActionResult Add(EmployeeViewModel vm)
		{
			if (ModelState.IsValid)
			{
				var newEmployee = new Employee
				{
					EmployeeId = vm.EmployeeId,
					Firstname = vm.Employee.Firstname,
					Lastname = vm.Employee.Lastname,
					Birthdate = vm.Employee.Birthdate,
					Hiredate = vm.Employee.Hiredate,
					ManagerId = vm.Employee.ManagerId
				};

				_context.Employees.Add(newEmployee);
				_context.SaveChanges();
				return RedirectToAction("Index", "Home");
			}
			vm.Employees = _context.Employees.ToList();
			return View(vm);
		}
	}
}