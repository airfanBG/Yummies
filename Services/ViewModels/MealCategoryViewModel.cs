﻿using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class MealCategoryViewModel:IMealCategoryViewModel
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public string MealCategoryId { get; set; }
        public List<MealViewModel> Meals { get; set; }
        public List<MenuMealCategoryViewModel> MenuMealCategoryViewModels { get; set; }
    }
}
