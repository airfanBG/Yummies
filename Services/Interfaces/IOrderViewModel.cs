using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IOrderViewModel:IBaseViewModel
    {
        public CustomerViewModel Customer { get; set; }
        public List<OrderMealsViewModel> OrderedMeals { get; set; }
        public List<OrderDrinksViewModel> OrderDrinks { get; set; }
    }
}
