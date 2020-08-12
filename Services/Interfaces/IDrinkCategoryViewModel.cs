using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IDrinkCategoryViewModel:ICategoryViewModel
    {
        public string DrinkId { get; set; }
        public DrinkViewModel DrinkViewModel { get; set; }
        public string CategoryId { get; set; }
        public DrinkCategoryViewModel CategoryViewModel { get; set; }
    }
}
