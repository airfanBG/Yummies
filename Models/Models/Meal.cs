using Models.Interfaces;
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
        public MealCategory MealCategory { get; set; }

    }
}
