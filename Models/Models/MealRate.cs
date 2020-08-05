using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Models
{
    public class MealRate: BaseEntity<string>
    {
        public string MealId { get; set; }
        public Meal Meal { get; set; }
        [Range(1,10)]
        public int Rate { get; set; }
    }
}
