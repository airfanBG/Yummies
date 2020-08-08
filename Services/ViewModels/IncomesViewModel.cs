using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class IncomesViewModel
    {
        public int Year { get; set; }
        public MonthModel MonthModel { get; set; }
        public decimal Total { get; set; }
    }
    public class MonthModel
    {
        public int MonthId { get; set; }
        public string Month { get; set; }
    }
}
