using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuarterlySales.Models;
using System.Diagnostics;

namespace QuarterlySales.Controllers
{
    public class HomeController : Controller
    {
        private SalesContext _context { get; set; }
        public HomeController( SalesContext ctx ) => _context = ctx;

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

        [HttpPost]
        public IActionResult Index( Employee employee )
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(employee);
            }
        }

        [HttpGet]
        public IActionResult Cancel( int id )
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", new { id });
            }
        }
    }
}