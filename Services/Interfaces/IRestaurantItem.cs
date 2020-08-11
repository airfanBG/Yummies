using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IRestaurantItem:IBaseViewModel
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
