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
            var res = await ServiceConnector.Context.Set<Order>().Include(x => x.OrderedMeals).ThenInclude(x => x.Meal.Recipe.RecepeeIngradients).Where(x => x.HasPaid == true && x.isFinished == false).ToListAsync();
            var orders = MapperConfigurator.Mapper.Map<List<OrderViewModel>>(res);
            return orders;
        }
        public async Task<OrderMealsViewModel> StartMealPreparing(string orderId, string mealId)
        {
            var res = await ServiceConnector.Context.Set<OrderMeals>()
                .Include(x => x.Meal)
                .ThenInclude(x => x.Recipe)
                .ThenInclude(x => x.RecepeeIngradients)
                .ThenInclude(x => x.Ingradient)
                .ThenInclude(x=>x.IngradientMetric)
               .Where(x => x.OrderId == orderId && x.MealId == mealId).FirstOrDefaultAsync();//x.OrderedMeals.)

            var data = MapperConfigurator.Mapper.Map<OrderMealsViewModel>(res);
            return data;
        }
    }
}
