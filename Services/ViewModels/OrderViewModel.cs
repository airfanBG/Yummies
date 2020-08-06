using Services.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Services.ViewModels
{
    public class OrderViewModel:IBaseViewModel
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public CustomerViewModel Customer { get; set; }
        public ICollection<OrderMealsViewModel> OrderedMeals { get; set; }
        public ICollection<OrderDrinksViewModel> OrderDrinks { get; set; }
        public bool HasPaid { get; set; } = false;
        [MaxLength(200)]
        public string OrderComment { get; set; }
    }
}