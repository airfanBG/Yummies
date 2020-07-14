using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Models
{
    public class Order : BaseEntity
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderMeals> OrderedMeals { get; set; }
        public bool HasPaid { get; set; } = false;
        [MaxLength(200)]
        public string OrderComment { get; set; }
    }

}

