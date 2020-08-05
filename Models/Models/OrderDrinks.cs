using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class OrderDrinks: BaseEntity<string>
    {
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public Drink Drink { get; set; }
        public string DrinkId { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
    }
}
