using Microsoft.Extensions.Primitives;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.ViewModels
{
    public class IngradientMetricViewModel:IBaseViewModel
    {
        public string Id { get; set; }
        public string MetricValue { get; set; }
        public List<IngradientViewModel> Ingradients { get; set; }
    }
}