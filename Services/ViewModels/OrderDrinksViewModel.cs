using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class OrderDrinksViewModel:IOrderDrink
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public OrderDrinksViewModel Order { get; set; }
        public DrinkViewModel Drink { get; set; }
        public string DrinkId { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
