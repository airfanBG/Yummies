using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class DrinkCategoryViewModel
    {
        public string DrinkId { get; set; }
        public DrinkViewModel DrinkViewModel { get; set; }
        public string CategoryId { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }
    }
}
