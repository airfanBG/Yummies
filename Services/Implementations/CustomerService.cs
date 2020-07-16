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
        private ApplicationDbContext Context { get; }
        public CustomerService(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task Add(CustomerViewModel model)
        {
            var res = MapperConfigurator.Mapper.Map<Customer>(model);
            Context.Customers.Add(res);
            await Context.SaveChangesAsync();
        }

        public async Task Remove(string id)
        {
            var order = await Context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            Context.Customers.Remove(order);
            await Context.SaveChangesAsync();
        }

        public async Task<ICollection<CustomerViewModel>> GetAll()
        {
            var models= await Context.Customers.ToListAsync();

            return MapperConfigurator.Mapper.Map<List<CustomerViewModel>>(models);
        }

        public async Task Update(CustomerViewModel model)
        {
            var res = MapperConfigurator.Mapper.Map<Customer>(model);

            Context.Customers.Update(res);
            await Context.SaveChangesAsync();
        }

    }
}
