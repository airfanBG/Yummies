using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IOrderViewModel
    {
        public ICollection<IOrderMeal> OrderedMeals { get; set; }
        public ICollection<IOrderDrink> OrderDrinks { get; set; }
    }
}
