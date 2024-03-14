using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuarterlySales.Models;

namespace QuarterlySales.Controllers
{
	public class SaleController : Controller
	{
		private SalesContext _context { get; set; }
		public SaleController(SalesContext ctx) => _context = ctx;

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.Action = "Add Sale";
			ViewBag.Sales = _context.Sales.OrderBy(s => s.Quarter).ToList();
			return View("Add", new Sale());
		}
	}
}
