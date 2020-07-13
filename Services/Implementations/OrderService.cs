using Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class OrderService : IBaseOperations
    {
        private ApplicationDbContext Context { get; }
        public OrderService(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task Add(IModel model)
        {
            Context.Orders.Add((Order)model);
            await Context.SaveChangesAsync();
        }

        public async Task Remove(string id)
        {
            var order = await Context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            Context.Orders.Remove(order);
            await Context.SaveChangesAsync();
        }

        public async Task<ICollection<IModel>> GetAll()
        {
            return await Task.Run(()=>(ICollection<IModel>)Context.Orders.Select(x => new Order()).ToListAsync());
        }

        public async Task Update(IModel model)
        {
            Context.Update((Order)model);
            await Context.SaveChangesAsync();
        }
    }
}
