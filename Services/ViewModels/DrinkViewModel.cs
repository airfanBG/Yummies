using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class DrinkViewModel
    {
        public string Id { get; set; }
        public string DrinkName { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public List<DrinkCategoryViewModel> DrinkCategoryViewModels { get; set; }
    }
}
