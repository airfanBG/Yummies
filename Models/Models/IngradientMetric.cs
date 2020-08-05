using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class IngradientMetric: BaseEntity
    {
        public string MetricValue { get; set; }
        public ICollection<Ingradient> Ingradients { get; set; }
    }
}
