using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class DrinkViewModel:IDrinkViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public ICollection<ICategoryViewModel> DrinkCategoryViewModels { get; set; }
        public string Description { get; set; }
    }
}
