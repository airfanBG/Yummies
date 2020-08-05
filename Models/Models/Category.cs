using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class Category:BaseEntity
    {
        
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public ICollection<Meal> Meals { get; set; }
        public ICollection<MenuMealCategory> MenuMealCategories { get; set; }
        public ICollection<DrinkCategory> DrinkCategories { get; set; }
    }
}
