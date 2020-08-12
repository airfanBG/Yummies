using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IMealCategoryViewModel:ICategoryViewModel
    {
        public string MealCategoryId { get; set; }
        public List<MealViewModel> Meals { get; set; }
        public List<MenuMealCategoryViewModel> MenuMealCategoryViewModels { get; set; }
    }
}
