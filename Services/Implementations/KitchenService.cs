using Microsoft.EntityFrameworkCore;
using Models.Models;
using Services.Interfaces;
using Services.Mapping;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class KitchenService
    {
        public IServiceConnector ServiceConnector { get; set; }
        public KitchenService(IServiceConnector connector)
        {
            ServiceConnector = connector;
        }
        public async Task<List<OrderViewModel>> GetAllOrdersAsync()
        {
            var res = await ServiceConnector.Context.Set<Order>().Include(x=>x.OrderedMeals).ThenInclude(x=>x.Meal).Where(x => x.HasPaid == true && x.isFinished == false).ToListAsync();
            var orders = MapperConfigurator.Mapper.Map<List<OrderViewModel>>(res);
            return orders;
        }
    }
}
