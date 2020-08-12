using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IInfrastructureViewModels
    {
        public string Id { get; set; }
        public List<OrderMealsViewModel> OrderMealsViews { get; set; }
        public List<OrderDrinksViewModel> OrderDrinksViewModels { get; set; }
    }
}
