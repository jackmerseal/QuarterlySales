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
            ViewBag.Action = "Add Employee";
            var viewModel = new EmployeeViewModel
            {
                Employees = _context.Employees.ToList() // Fetching list of employees
            };
            return View("Add", viewModel);
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viewModel.Employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            viewModel.Employees = _context.Employees.ToList(); // Fetching list of employees again
            return View(viewModel);
        }
    }
}