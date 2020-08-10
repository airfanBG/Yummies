using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Models.Models;
using Services.Common;
using Services.Interfaces;
using Services.Mapping;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class AdminService
    {
        private IServiceConnector ServiceConnector { get; }
        private readonly UserStatistics _statistics;
       
        public AdminService(IServiceConnector connector, UserStatistics statistics)
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
            decimal meals = await Task.Run(() => ServiceConnector.Context.Set<OrderMeals>().Include(x => x.Order)
                 .Where(x => x.CreatedAt.Date == DateTime.Today && x.Order.HasPaid == true)
                 .GroupBy(x => x.OrderId, (a, b) => new { a, Total = b.Sum(z => z.SubTotal) })
                 .Select(x => new
                 {
                     x.Total,
                     x.a
                 }).Sum(x => x.Total));
            decimal drinks = await Task.Run(() => ServiceConnector.Context.Set<OrderDrinks>().Include(x => x.Order)
                 .Where(x => x.CreatedAt.Date == DateTime.Today && x.Order.HasPaid == true)
                 .GroupBy(x => x.OrderId, (a, b) => new { a, Total = b.Sum(z => z.SubTotal) })
                 .Select(x => new
                 {
                     x.Total,
                     x.a
                 }).Sum(x => x.Total));

            return meals + drinks;
        }
        public async Task<List<IncomesViewModel>> GetByMonthIncomes()
        {

            var meals = await ServiceConnector.Context.Set<OrderMeals>().Include(x => x.Order)
                 .Where(x => x.Order.HasPaid == true && x.Order.isFinished == true)
                 .GroupBy(z => new { month = z.CreatedAt.Month, year = z.CreatedAt.Year }, (period, OrderedMeals) => new { Month = period.month, Year = period.year, Total = OrderedMeals.Sum(z => z.SubTotal) })
                 .Select(x => new IncomesViewModel()
                 {
                     Total = x.Total,
                     Year = x.Year,
                     MonthModel = new MonthModel()
                     {
                         MonthId = x.Month,
                         Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Month)
                     }
                 }).ToListAsync();
            var drinks = await ServiceConnector.Context.Set<OrderDrinks>().Include(x => x.Order)
                 .Where(x => x.Order.HasPaid == true && x.Order.isFinished == true)
                  .GroupBy(z => new { month = z.CreatedAt.Month, year = z.CreatedAt.Year }, (period, OrderedMeals) => new { Month = period.month, Year = period.year, Total = OrderedMeals.Sum(z => z.SubTotal) })
                 .Select(x => new IncomesViewModel()
                 {
                     Total = x.Total,
                     Year = x.Year,
                     MonthModel = new MonthModel()
                     {
                         MonthId = x.Month,
                         Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Month)
                     }
                 }).ToListAsync();
            var combine = meals.Union(drinks)
                .GroupBy(x => new
                {
                    x.MonthModel.Month,
                    x.MonthModel.MonthId,
                    x.Year
                },
                    (periods, data) =>
                    new IncomesViewModel
                    {
                        MonthModel = new MonthModel()
                        {
                            MonthId = periods.MonthId,
                            Month = periods.Month

                        }
                        ,
                        Year = periods.Year,
                        Total = data.Sum(x => x.Total)
                    })
                .ToList();

            return combine;
        }
        public async Task<List<SoldProductsViewModel>> GetByDateIncomes(string date)
        {
            var res =await ServiceConnector.Context.Set<Order>()
                .Include(x => x.OrderDrinks)
                .ThenInclude(x => x.Drink)
                .Include(x => x.OrderedMeals)
                .ThenInclude(x => x.Meal)
                .Where(x => x.CreatedAt.Date == DateTime.Parse(date) && x.HasPaid == true)
                .Select(x => new SoldProductsViewModel()
                {
                    //Meals=MapperConfigurator.Mapper.Map<List<MealViewModel>>(x.OrderedMeals.Select(z=>z.Meal)),
                    //Drinks= MapperConfigurator.Mapper.Map<List<DrinkViewModel>>(x.OrderDrinks.Select(z => z.Drink)),
                    OrderDrinksViewModels=MapperConfigurator.Mapper.Map<List<OrderDrinksViewModel>>(x.OrderDrinks),
                    OrderMealsViews= MapperConfigurator.Mapper.Map<List<OrderMealsViewModel>>(x.OrderedMeals),
                }).ToListAsync();
           
            return res;
        }
    }

}
