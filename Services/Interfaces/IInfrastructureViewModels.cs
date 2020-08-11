using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IInfrastructureViewModels
    {
        public string Id { get; set; }
        public List<IOrderItemViewModel> OrderMealsViews { get; set; }
        public List<IOrderItemViewModel> OrderDrinksViewModels { get; set; }
    }
}
