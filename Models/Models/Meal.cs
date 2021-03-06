﻿using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class Meal : BaseEntity
    {
        public string MealName { get; set; }
        public decimal Price { get; set; }
        public string TimeForPrepare { get; set; }
        public string Image { get; set; }
        public ICollection<OrderMeals> OrderMeals { get; set; }
        public string MealCategoryId { get; set; }
        public Category MealCategory { get; set; }
        public string MealDescription { get; set; }
        public ICollection<MealRate> MealRates { get; set; }
        public string RecipeId { get; set; }
        public Recipe Recipe { get; set; }

    }
}
