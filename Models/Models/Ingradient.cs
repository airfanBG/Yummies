using Models.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Models.Models
{
    public class Ingradient: BaseEntity<string>
    {
        public string IngradientName { get; set; }
        public ICollection<RecipeIngradients> RecepeeIngradients { get; set; }
        public string IngradientMetricId { get; set; }
        public IngradientMetric IngradientMetric { get; set; }
    }
}