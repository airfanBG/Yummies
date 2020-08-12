using Services.Interfaces;
using System.Collections.Generic;

namespace Services.ViewModels
{
    public class IngradientViewModel:IBaseViewModel
    {
        public string Id { get; set; }
        public string IngradientName { get; set; }
        public List<RecepeeIngradientsViewModel> RecepeeIngradients { get; set; }
        public string IngradientMetricId { get; set; }
        public IngradientMetricViewModel IngradientMetric { get; set; }
    }
}