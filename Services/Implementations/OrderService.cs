using Data;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Models;
using Services.Interfaces;
using Services.Mapping;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class OrderService
    {
        private ApplicationDbContext Context { get; set; }

        public OrderService(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task Add(OrderViewModel model)
        {
           // Context = new ApplicationDbContext();
            var res = MapperConfigurator.Mapper.Map<Order>(model);
            Context.Orders.Add(res);
            await Context.SaveChangesAsync();
        }
        public async Task<OrderViewModel> FindOrder(string id)
        {
            var order = await Context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order!=null)
            {
                var res = MapperConfigurator.Mapper.Map<OrderViewModel>(order);
                return res;
            }
            return null;
        }

        public async Task Remove(string id)
        {
           // Context = new ApplicationDbContext();
            Order order = await Context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            Context.Orders.Remove(order);
            await Context.SaveChangesAsync();
        }

        public async Task<ICollection<OrderViewModel>> GetAll()
        {
            // Context = new ApplicationDbContext();
            var models =await Context.Orders.ToListAsync();

            return MapperConfigurator.Mapper.Map<List<OrderViewModel>>(models);
        }

        public async Task<ICollection<OrderViewModel>> GetNotFinishedOrders(string userId)
        {
            //Context = new ApplicationDbContext();
            var orders = await Context.Orders.Include(x => x.Customer).Include(x => x.OrderedMeals).ThenInclude(x => x.Meal).Where(x => x.Customer.UserId == userId).Where(x => x.HasPaid == false).ToListAsync();
            var result = MapperConfigurator.Mapper.Map<List<OrderViewModel>>(orders);
            return result;
        }
        public async Task Update(OrderViewModel model)
        {
            // Context = new ApplicationDbContext();
            var res = MapperConfigurator.Mapper.Map<Order>(model);

            Context.Update(res);
            await Context.SaveChangesAsync();
        }
        public async Task<decimal> TotalSum(string clientId)
        {
            //Context = new ApplicationDbContext();
            decimal res = await Context.Orders
                .Where(x => x.CustomerId == clientId && x.HasPaid == false)
                .Select(x => x.OrderedMeals.Sum(p => p.Meal.Price) / (1 + ((decimal)x.Customer.ShoppingCard.CardStatus / (decimal)100)))
                .FirstOrDefaultAsync();
            return res;
        }
        public async Task<int> FinishOrder(string orderId)
        {
            //Context = new ApplicationDbContext();
            Order getOrder = Context.Orders.Where(x => x.Id == orderId).FirstOrDefault();
            getOrder.HasPaid = true;

            Context.Orders.Update(getOrder);
            int res = await Context.SaveChangesAsync();
            return res;
        }
    }
}
