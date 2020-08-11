using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.ViewModels
{
    public class PaginateViewModel : ICombinedRestaurantStatistics
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal SubTotal { get; set; }
    }
}
