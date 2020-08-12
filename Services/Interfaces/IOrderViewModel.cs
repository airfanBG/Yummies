using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IOrderViewModel:IBaseViewModel
    {
        public ICustomerViewModel Customer { get; set; }
        public ICollection<IOrderMeal> OrderedMeals { get; set; }
        public ICollection<IOrderDrink> OrderDrinks { get; set; }
    }
}
