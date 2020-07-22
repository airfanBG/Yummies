using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class OrderDataViewModel
    {
        public int Quantity { get; set; }
        public string MealId { get; set; }
        public string Comment { get; set; }
    }
}
