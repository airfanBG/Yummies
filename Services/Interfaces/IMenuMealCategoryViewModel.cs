﻿using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IMenuMealCategoryViewModel
    {
        public string MenuId { get; set; }
        public MenuViewModel MenuViewModel { get; set; }
        public string MealCategoryId { get; set; }
        public MealCategoryViewModel MealCategoryViewModel { get; set; }
    }
}
