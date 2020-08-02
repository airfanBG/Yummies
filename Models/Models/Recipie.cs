using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class Recipe:BaseEntity
    {
        public string MealName { get; set; }
        public string Description { get; set; }
        public string TimeForPrepare { get; set; }
        public ICollection<RecipeIngradients> RecepeeIngradients { get; set; }
    }
}
