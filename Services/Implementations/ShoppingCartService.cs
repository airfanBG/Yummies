using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implementations
{
    public class ShoppingCartService
    {
        private IServiceConnector ServiceConnector { get; }

        public ShoppingCartService(IServiceConnector serviceConnector)
        {
            this.ServiceConnector = serviceConnector;
        }
        public async Task<int> AddNewOrder()
        {

        }
    }
}
