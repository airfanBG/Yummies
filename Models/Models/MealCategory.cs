using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class MealCategory:BaseEntity
    {
        public string CategoryName { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
