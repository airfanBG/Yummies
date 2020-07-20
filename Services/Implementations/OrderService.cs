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
        private ServiceConnector ServiceConnector { get; set; }

        public OrderService(ServiceConnector serviceConnector)
        {
            ServiceConnector = serviceConnector;
        }

        public async Task Add(OrderViewModel model)
        {
            var res = MapperConfigurator.Mapper.Map<Order>(model);
            await ServiceConnector.Orders.Add(res);
            await ServiceConnector.SaveChangesAsync();
        }
        public async Task<OrderViewModel> FindOrder(string id)
        {
            var order = await ServiceConnector.Orders.FindById(id);
            if (order!=null)
            {
                var res = MapperConfigurator.Mapper.Map<OrderViewModel>(order);
                return res;
            }
            return null;
        }

        public async Task Remove(string id)
        {
            await ServiceConnector.Orders.Remove(id);
           
            await ServiceConnector.SaveChangesAsync();
        }

        public async Task<ICollection<OrderViewModel>> GetAll()
        {
            var models =await ServiceConnector.Orders.GetAll();

            return MapperConfigurator.Mapper.Map<List<OrderViewModel>>(models);
        }

        public async Task<ICollection<OrderViewModel>> GetNotFinishedOrders(string userId)
        {
            //Context = new ApplicationDbContext();
            var orders = await ServiceConnector.Context.Set<Order>().Include(x => x.Customer).Include(x => x.OrderedMeals).ThenInclude(x => x.Meal).Where(x => x.Customer.UserId == userId).Where(x => x.HasPaid == false).ToListAsync();
            var result = MapperConfigurator.Mapper.Map<List<OrderViewModel>>(orders);
            return result;
        }
        public async Task Update(OrderViewModel model)
        {
            var res = MapperConfigurator.Mapper.Map<Order>(model);
            await ServiceConnector.Orders.Update(res);
            await ServiceConnector.SaveChangesAsync();
        }
        public async Task<decimal> TotalSum(string clientId)
        {
            decimal res = await ServiceConnector.Context.Set<Order>()
                .Where(x => x.CustomerId == clientId && x.HasPaid == false)
                .Select(x => x.OrderedMeals.Sum(p => p.Meal.Price) / (1 + ((decimal)x.Customer.ShoppingCard.CardStatus / (decimal)100)))
                .FirstOrDefaultAsync();
            return res;
        }
        public async Task<int> FinishOrder(string orderId)
        {
         
            var getOrder =await this.ServiceConnector.Orders.FindById(orderId);
            getOrder.HasPaid = true;

            await this.ServiceConnector.Orders.Update(getOrder);
            int res = await ServiceConnector.SaveChangesAsync();
            return res;
        }
    }
}
