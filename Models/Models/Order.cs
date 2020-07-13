using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class Order :BaseEntity
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Meal> OrderedMeals { get; set; }
        public ShoppingCard ShoppingCard { get; set; }
        public bool HasPaid { get; set; } = false;
       
    }
}
