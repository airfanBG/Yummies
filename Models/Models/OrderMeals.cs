using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class OrderMeals:BaseEntity
    {
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
