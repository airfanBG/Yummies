using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Models
{
    public class Order : BaseEntity<string>
    {
        public Order()
        {
            OrderedMeals = new List<OrderMeals>();
            OrderDrinks = new List<OrderDrinks>();
        }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderMeals> OrderedMeals { get; set; }
        public ICollection<OrderDrinks> OrderDrinks { get; set; }
        public bool HasPaid { get; set; } = false;
        [MaxLength(200)]
        public string OrderComment { get; set; }
        public bool isFinished { get; set; } = false;
    }

}

