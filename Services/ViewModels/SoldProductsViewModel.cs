using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class SoldProductsViewModel:IBaseViewModel
    {
        //public List<MealViewModel> Meals { get; set; }
        //public List<DrinkViewModel> Drinks { get; set; }
        public string Id { get; set; }
        public List<OrderMealsViewModel> OrderMealsViews { get; set; }
        public List<OrderDrinksViewModel> OrderDrinksViewModels { get; set; }

    }
    //public class PaginationViewModel
    //{
    //    public List<SoldProductsViewModel> SoldProductsViewModels { get; set; }
    //    public int CurrentPage { get; set; } = 1;
    //}
}
