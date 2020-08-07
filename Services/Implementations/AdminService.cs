using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Models.Models;
using Services.Common;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class AdminService
    {
        private IServiceConnector ServiceConnector { get; }
        private readonly Statistics _statistics;
        public AdminService(IServiceConnector connector, Statistics statistics)
        {
            ServiceConnector = connector;
            _statistics = statistics;
        }
        public async Task<int> GetNewClients()
        {

            var res = await ServiceConnector.Users.GetAll(x => x.CreatedAt > _statistics.LastDateCheckUsers);
            _statistics.LastDateCheckUsers = DateTime.UtcNow;
            return res.Count;
        }
        public async Task<int> GetTotalDailyOrders()
        {

            var res = await ServiceConnector.Orders.GetAll(x => x.CreatedAt.Date == DateTime.UtcNow.Date);

            return res.Count;
        }
        public async Task<decimal> GetDailyIncomes()
        {
            decimal res =await Task.Run(()=> ServiceConnector.Context.Set<OrderMeals>().Include(x => x.Order)
                .Where(x => x.CreatedAt.Date == DateTime.Today && x.Order.HasPaid == true)
                .GroupBy(x => x.OrderId,(a,b)=>new {a,Total=b.Sum(z=>z.SubTotal) })
                .Select(x => new
                {
                   x.Total,
                   x.a
                }).Sum(x=>x.Total));
                
            return res;
        }
    }
}
