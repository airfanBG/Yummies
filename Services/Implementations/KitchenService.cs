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
        public async Task<List<OrderViewModel>> GetAllOrdersAsync(Statuses status=Statuses.NotStarted)
        {
            var res = await ServiceConnector.Context.Set<Order>().Include(x => x.OrderedMeals).ThenInclude(x => x.Meal.Recipe.RecepeeIngradients).Where(x => x.HasPaid == true && x.isFinished == false).Select(x => new Order()
            {
                Customer=x.Customer,
                CustomerId=x.CustomerId,
                Id=x.Id,
                HasPaid=x.HasPaid,
                isFinished=x.isFinished,
                OrderComment=x.OrderComment,
                CreatedAt=x.CreatedAt,
                OrderedMeals = x.OrderedMeals.Where(z => z.Statuses == status).Select(a => new OrderMeals()
                {
                    Meal = a.Meal,
                    MealId = a.MealId,
                    Order = a.Order,
                    OrderId = a.OrderId,
                    Id = a.Id,
                    Quantity = a.Quantity,
                    Statuses = a.Statuses,
                    SubTotal = a.SubTotal,
                    CreatedAt=a.CreatedAt
                }).ToList()
            }).ToListAsync();
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
                .ThenInclude(x => x.IngradientMetric)
               .Where(x => x.OrderId == orderId && x.MealId == mealId).FirstOrDefaultAsync();

            var data = MapperConfigurator.Mapper.Map<OrderMealsViewModel>(res);
            res.Statuses = Statuses.Started;

            var updateStatus =await ServiceConnector.OrderMeals.Update(res);
            return data;
        }
        public async Task<int> RejectMealPreparing(string orderId, string mealId, string comment)
        {
            var res = await ServiceConnector.Context.Set<OrderMeals>()
               .Where(x => x.OrderId == orderId && x.MealId == mealId).FirstOrDefaultAsync();
            res.Statuses = Statuses.Cancelled;

            var status = await ServiceConnector.OrderMeals.Update(res);

            return status;
        }
    }
}
