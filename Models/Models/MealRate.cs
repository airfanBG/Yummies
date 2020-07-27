using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class MealRate:BaseEntity
    {
        public string MealId { get; set; }
        public Meal Meal { get; set; }
        public int Rate { get; set; }
    }
}
