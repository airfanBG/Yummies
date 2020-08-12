using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IOrderDrink:IOrderItemViewModel
    {
        public OrderDrinksViewModel Order { get; set; }
        public DrinkViewModel Drink { get; set; }
    }
}
