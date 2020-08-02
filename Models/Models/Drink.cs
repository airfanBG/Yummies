using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class Drink:BaseEntity
    {
        public string DrinkName { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
