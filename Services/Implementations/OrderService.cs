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
        public IServiceConnector ServiceConnector { get;protected set; }

        public OrderService(ServiceConnector serviceConnector)
        {
            ServiceConnector = serviceConnector;
        }


        public async Task<ICollection<OrderViewModel>> GetNotFinishedOrders(string userId)
        {
            var orders = await ServiceConnector.Context.Set<Order>().Include(x => x.Customer).Include(x=>x.Customer.ShoppingCard).Include(x => x.OrderedMeals).ThenInclude(x => x.Meal).Where(x => x.Customer.UserId == userId).Where(x => x.HasPaid == false).ToListAsync();
            var result = MapperConfigurator.Mapper.Map<List<OrderViewModel>>(orders);
            return result;
        }
       
        public async Task<decimal> TotalSum(string userId)
        {
            var clientId = ServiceConnector.Context.Set<Customer>().FirstOrDefault(x => x.UserId == userId).Id;
            var res = await Task.Run(() => ServiceConnector.Orders.GetAll(x => x.CustomerId == clientId && x.HasPaid == false).Result.Select(x=>x.OrderedMeals.Sum(p=>p.Meal.Price)/(1+((decimal)x.Customer.ShoppingCard.CardStatus/(decimal)100))).FirstOrDefault());
               
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
