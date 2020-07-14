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

        public async Task Add(BaseEntity model)
        {
            Context.Orders.Add((Order)model);
            await Context.SaveChangesAsync();
        }

        public async Task Remove(string id)
        {
            Order order = await Context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            Context.Orders.Remove(order);
            await Context.SaveChangesAsync();
        }

        public async Task<ICollection<BaseEntity>> GetAll()
        {
            return await Context.Orders.ToListAsync<BaseEntity>();
        }

        public async Task Update(BaseEntity model)
        {
            Context.Update((Order)model);
            await Context.SaveChangesAsync();
        }
        public async Task<decimal> TotalSum(string clientId)
        {
            decimal res = await Context.Orders
                .Where(x => x.CustomerId == clientId && x.HasPaid == false)
                .Select(x => x.OrderedMeals.Sum(p => p.Meal.Price) - ((decimal)x.Customer.ShoppingCard.CardStatus /(decimal) 100))
                .FirstOrDefaultAsync();
            return res;
        }
        public async Task<int> FinishOrder(string orderId)
        {
            Order getOrder = Context.Orders.Where(x => x.Id == orderId).FirstOrDefault();
            getOrder.HasPaid = true;

            Context.Orders.Update(getOrder);
            int res = await Context.SaveChangesAsync();
            return res;
        }
    }
}
