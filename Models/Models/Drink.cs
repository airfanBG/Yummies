using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class Drink: BaseEntity<string>
    {
        public string DrinkName { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public List<DrinkCategory> DrinkCategories { get; set; }
        public List<OrderDrinks> OrderDrinks { get; set; }
    }
}
