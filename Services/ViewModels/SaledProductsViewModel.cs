using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class SaledProductsViewModel
    {
        //public List<MealViewModel> Meals { get; set; }
        //public List<DrinkViewModel> Drinks { get; set; }
        public List<OrderMealsViewModel> OrderMealsViews { get; set; }
        public List<OrderDrinksViewModel> OrderDrinksViewModels { get; set; }
    }
}
