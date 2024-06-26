﻿using QuarterlySales.Models.DomainModels;

namespace QuarterlySales.Models.ViewModels
{
    public class SaleViewModel : Sale
    {
        //public IEnumerable<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
        public Sale Sale { get; set; }
        public int Quarter { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Sale> Sales { get; set; }
        public int EmployeeId { get; set; }
        public int SaleId { get; set; }

        public SaleViewModel()
        {
            Employees = new List<Employee>();
            Sales = new List<Sale>();
        }
    }
}