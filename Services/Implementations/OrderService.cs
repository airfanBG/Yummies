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
    public class OrderService : IBaseService
    {
        private ApplicationDbContext Context { get; set; }
       

        public async Task Add(BaseEntity model)
        {
            Context = new ApplicationDbContext();
            Context.Orders.Add((Order)model);
            await Context.SaveChangesAsync();
        }

        public async Task Remove(string id)
        {
            Context = new ApplicationDbContext();
            Order order = await Context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            Context.Orders.Remove(order);
            await Context.SaveChangesAsync();
        }

        public async Task<ICollection<BaseEntity>> GetAll()
        {
            Context = new ApplicationDbContext();
            return await Context.Orders.ToListAsync<BaseEntity>();
        }

        public async Task<ICollection<Order>> GetNotFinishedOrders(string userId)
        {
            Context = new ApplicationDbContext();
            var orders=await Context.Orders.Include(x=>x.Customer).Include(x=>x.OrderedMeals).ThenInclude(x=>x.Meal).Where(x=>x.Customer.UserId==userId).Where(x => x.HasPaid == false).ToListAsync();
            
            return orders;
        }
        public async Task Update(BaseEntity model)
        {
            Context = new ApplicationDbContext();
            Context.Update((Order)model);
            await Context.SaveChangesAsync();
        }
        public async Task<decimal> TotalSum(string clientId)
        {
            Context = new ApplicationDbContext();
            decimal res = await Context.Orders
                .Where(x => x.CustomerId == clientId && x.HasPaid == false)
                .Select(x => x.OrderedMeals.Sum(p => p.Meal.Price) / (1+((decimal)x.Customer.ShoppingCard.CardStatus /(decimal) 100)))
                .FirstOrDefaultAsync();
            return res;
        }
        public async Task<int> FinishOrder(string orderId)
        {
            Context = new ApplicationDbContext();
            Order getOrder = Context.Orders.Where(x => x.Id == orderId).FirstOrDefault();
            getOrder.HasPaid = true;

            Context.Orders.Update(getOrder);
            int res = await Context.SaveChangesAsync();
            return res;
        }
    }
}
