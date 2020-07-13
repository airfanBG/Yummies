using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class Order :IBaseEntity, IAuditInfo
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Meal> OrderedMeals { get; set; }
        public ShoppingCard ShoppingCard { get; set; }
        public bool HasPaid { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
