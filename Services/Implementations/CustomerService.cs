using Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Models;
using Services.Interfaces;
using Services.Mapping;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class CustomerService
    {
        private ServiceConnector ServiceConnector { get; }
        public CustomerService(ServiceConnector serviceConnector)
        {
            ServiceConnector = serviceConnector;
        }

        public async Task Add(CustomerViewModel model)
        {
            var res = MapperConfigurator.Mapper.Map<Customer>(model);
            await ServiceConnector.Customers.Add(res);
            await ServiceConnector.SaveChangesAsync();
        }

        public async Task Remove(string id)
        {
            var order = await ServiceConnector.Customers.Remove(id);
          
            await ServiceConnector.SaveChangesAsync();
        }

        public async Task<ICollection<CustomerViewModel>> GetAll()
        {
            var models= await ServiceConnector.Customers.GetAll();

            return MapperConfigurator.Mapper.Map<List<CustomerViewModel>>(models);
        }

        public async Task Update(CustomerViewModel model)
        {
            var res = MapperConfigurator.Mapper.Map<Customer>(model);

            await ServiceConnector.Customers.Update(res);
            await ServiceConnector.SaveChangesAsync();
        }

    }
}
