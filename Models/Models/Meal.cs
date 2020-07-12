using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class Meal : IModel
    {
        public string Id { get; set; }
        public string MealName { get; set; }
        public double Price { get; set; }
        public string TimeForPrepare { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
