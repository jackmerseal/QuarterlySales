using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuarterlySales.Models;
using System.Diagnostics;

namespace QuarterlySales.Controllers
{
	public class HomeController : Controller
	{
		private SalesContext _context { get; set; }
		public HomeController(SalesContext ctx) => _context = ctx;

		[HttpGet]
		public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Employee employee)
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
    }
}
