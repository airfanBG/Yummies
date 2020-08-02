using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace Services.ViewModels
{
    public class IngradientMetricViewModel
    {
        public string Id { get; set; }
        public string MetricValue { get; set; }
        public ICollection<IngradientViewModel> Ingradients { get; set; }
    }
}