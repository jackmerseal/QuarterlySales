using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuarterlySales.Models;
using System.ComponentModel.DataAnnotations;

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
                var existingSale = _context.Sales.FirstOrDefault(s =>
                    s.SaleId != sale.SaleId &&
                    s.Quarter == sale.Quarter &&
                    s.Year == sale.Year &&
                    s.Amount == sale.Amount &&
                    s.EmployeeId == sale.EmployeeId);

                if (existingSale != null)
                {
                    var employeeName = sale.Employee != null ? sale.Employee.Name : "Unknown";
                    ModelState.AddModelError(string.Empty, errorMessage: $"Sales for {employeeName} for {sale.Year} Q{sale.Quarter} are already in the database");
                    var vm = new SaleViewModel
                    {
                        Sale = sale,
                        Employees = _context.Employees.ToList()
                    };
                    return View(vm);
                }

                if (sale.SaleId == 0)
                {
                    _context.Sales.Add(sale);
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            var viewModel = new SaleViewModel
            {
                Sale = sale,
                Employees = _context.Employees.ToList()
            };
            return View(viewModel);
        }



    }

}