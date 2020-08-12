using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class DrinkCategoryViewModel:ICategoryViewModel
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
        public string DrinkId { get; set; }
        public IDrinkViewModel DrinkViewModel { get; set; }
        public string CategoryId { get; set; }
        public ICategoryViewModel CategoryViewModel { get; set; }
    }
}
