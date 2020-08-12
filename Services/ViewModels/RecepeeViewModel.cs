using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class RecepeeViewModel:IBaseViewModel
    {
        public string Id { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public string TimeForPrepare { get; set; }
        public List<RecepeeIngradientsViewModel> RecepeeIngradients { get; set; }
    }
}
