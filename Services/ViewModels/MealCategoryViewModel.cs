using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class MealCategoryViewModel:ICategoryViewModel
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public string MealCategoryId { get; set; }
        public ICollection<IMealViewModel> Meals { get; set; }
        public ICollection<MenuMealCategoryViewModel> MenuMealCategoryViewModels { get; set; }
    }
}
