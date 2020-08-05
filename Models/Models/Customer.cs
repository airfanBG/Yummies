using Models.Interfaces;
using Models.Models.IdentityModels;
using System.Collections.Generic;

namespace Models.Models
{
    public class Customer:BaseEntity<string>
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }
        public string ShoppingCardId { get; set; }
        public ShoppingCard ShoppingCard { get; set; }

    }
}