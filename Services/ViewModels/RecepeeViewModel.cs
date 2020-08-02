using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class RecepeeViewModel
    {
        public string Id { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string TimeForPrepare { get; set; }
        public ICollection<RecepeeIngradientsViewModel> RecepeeIngradients { get; set; }
    }
}
