using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class DrinkCategory: BaseEntity<string>
    {
        public string DrinkId { get; set; }
        public Drink Drink { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
