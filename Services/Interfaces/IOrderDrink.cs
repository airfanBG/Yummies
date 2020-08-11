using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IOrderDrink:IOrderItemViewModel
    {
        public IOrderItemViewModel Order { get; set; }
        public IRestaurantItem Drink { get; set; }
    }
}
