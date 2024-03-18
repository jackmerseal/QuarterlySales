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
			var vm = new SaleViewModel();
			vm.Employees = _context.Employees.ToList();
			return View(vm);
		}

		[HttpPost]
		public IActionResult Add(SaleViewModel vm)
		{
			if (ModelState.IsValid)
			{
				if (vm.SaleId == 0)
				{
					_context.Sales.Add(vm.Sale);
				}
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(vm);
		}

	}
}
