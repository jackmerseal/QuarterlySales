using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuarterlySales.Models;

namespace QuarterlySales.Controllers
{
    public class EmployeeController : Controller
    {
		private const string EMPLOYEE_KEY = "employeeID";
		private SalesContext _context { get; set; }
        public EmployeeController(SalesContext ctx) => _context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add Employee";
            ViewBag.Employees = _context.Employees.OrderBy(e => e.Firstname).ToList();
            return View("Add", new Employee());
        }
    }
}
