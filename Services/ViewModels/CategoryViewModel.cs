using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class CategoryViewModel
    {
        public string CategoryName { get; set; }
        public string Image { get; set; }
        
        public ICollection<DrinkCategoryViewModel> DrinkCategories { get; set; }
    }
}
