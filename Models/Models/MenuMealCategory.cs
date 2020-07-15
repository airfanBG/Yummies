using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class MenuMealCategory:BaseEntity
    {
        public string MenuId { get; set; }
        public Menu Menu { get; set; }
        public string MealCategoryId { get; set; }
        public MealCategory MealCategory { get; set; }
    }
}
