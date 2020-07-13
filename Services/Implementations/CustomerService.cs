using Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class CustomerService:IBaseOperations
    {
        private ApplicationDbContext Context { get; }
        public CustomerService(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task Add(BaseEntity model)
        {
            Context.Customers.Add((Customer)model);
            await Context.SaveChangesAsync();
        }

        public async Task Remove(string id)
        {
            var order = await Context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            Context.Customers.Remove(order);
            await Context.SaveChangesAsync();
        }

        public async Task<ICollection<BaseEntity>> GetAll()
        {
            return await Context.Customers.ToListAsync<BaseEntity>();
        }

        public async Task Update(BaseEntity model)
        {
            Context.Update((Customer)model);
            await Context.SaveChangesAsync();
        }
    }
}
