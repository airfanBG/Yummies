using System.Collections.Generic;

namespace Services.ViewModels
{
    public class IngradientViewModel
    {
        public string IngradientName { get; set; }
        public ICollection<RecepeeIngradientsViewModel> RecepeeIngradients { get; set; }
        public string IngradientMetricId { get; set; }
        public IngradientMetricViewModel IngradientMetric { get; set; }
    }
}