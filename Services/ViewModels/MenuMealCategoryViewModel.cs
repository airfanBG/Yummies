﻿using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class MenuMealCategoryViewModel:IMenuMealCategoryViewModel
    {
        public string MenuId { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
        public string MealCategoryId { get; set; }
        public MealCategoryViewModel MealCategoryViewModel { get; set; }
    }
}
