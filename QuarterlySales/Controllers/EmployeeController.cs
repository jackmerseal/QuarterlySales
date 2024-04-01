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

		public EmployeeController( SalesContext context )
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
		public IActionResult Add( EmployeeViewModel vm )
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

		//private void AddErrorMessages(EmployeeViewModel vm)
		//{
		//	if (string.IsNullOrEmpty(vm.Employee.Firstname))
		//	{
		//		ModelState.AddModelError("Employee.Firstname", "First name is required.");
		//	}

		//	if (string.IsNullOrEmpty(vm.Employee.Lastname))
		//	{
		//		ModelState.AddModelError("Employee.Lastname", "Last name is required.");
		//	}

		//	if (vm.Employee.Birthdate == null)
		//	{
		//		ModelState.AddModelError("Employee.Birthdate", "Birthdate is required.");
		//	}
		//	else if (vm.Employee.Birthdate > DateTime.Today)
		//	{
		//		ModelState.AddModelError("Employee.Birthdate", "Date of birth must be in the past.");
		//	}

		//	if (vm.Employee.Hiredate == null)
		//	{
		//		ModelState.AddModelError("Employee.Hiredate", "Hiredate is required.");
		//	}
		//	else if (vm.Employee.Hiredate > DateTime.Today)
		//	{
		//		ModelState.AddModelError("Employee.Hiredate", "Date of hire must be in the past.");
		//	}
		//	else if (vm.Employee.Hiredate < new DateTime(1995, 1, 1))
		//	{
		//		ModelState.AddModelError("Employee.Hiredate", "Date of hire must not be before 1/1/1995.");
		//	}

		//	if (vm.Employee.ManagerId == 0)
		//	{
		//		ModelState.AddModelError("Employee.ManagerId", "Manager is required.");
		//	}
		//}
	}
}