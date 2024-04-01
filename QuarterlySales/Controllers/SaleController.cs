using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuarterlySales.Models;

namespace QuarterlySales.Controllers
{
    public class SaleController : Controller
    {
        private SalesContext _context { get; set; }
        public SaleController( SalesContext ctx ) => _context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            var vm = new SaleViewModel();
            vm.Employees = _context.Employees.ToList();
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add( [FromForm] Sale sale )
        {
            if (ModelState.IsValid)
            {
                if (sale.SaleId == 0)
                {
                    _context.Sales.Add(sale);
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            var vm = new SaleViewModel
            {
                Sale = sale,
                Employees = _context.Employees.ToList()
            };

            return View(vm);
        }
    }
}