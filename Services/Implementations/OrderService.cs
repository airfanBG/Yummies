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
        public IServiceConnector ServiceConnector { get; protected set; }
        private List<Order> Orders;

        public OrderService(ServiceConnector serviceConnector)
        {
            ServiceConnector = serviceConnector;
        }


        public async Task<ICollection<OrderViewModel>> GetNotFinishedOrdersAsync(string userId)
        {
            Orders = await ServiceConnector.Context.Set<Order>()
                .Include(x => x.Customer)
                .Include(x => x.Customer.ShoppingCard)
                .Include(x => x.OrderedMeals)
                .ThenInclude(x => x.Meal)
                .Include(x => x.OrderDrinks)
                .ThenInclude(x => x.Drink)
                .Where(x => x.Customer.UserId == userId && x.HasPaid == false).ToListAsync();

            var result = MapperConfigurator.Mapper.Map<List<OrderViewModel>>(Orders);
            return result;
        }

        public async Task<decimal> TotalSumAsync()
        {

            decimal mealsSum = 0;
            decimal drinksSum = 0;

            if (Orders.Select(x => x.OrderedMeals).Any())
            {
                mealsSum = await Task.Run(() => Orders.Select(x => x.OrderedMeals.Sum(p => p.Meal.Price * p.Quantity) / (1 + ((decimal)x.Customer.ShoppingCard.CardStatus / (decimal)100))).FirstOrDefault());
            }
            if (Orders.Select(x => x.OrderDrinks).Any())
            {
                drinksSum = await Task.Run(() => Orders.Select(x => x.OrderDrinks.Sum(p => p.Drink.Price * p.Quantity) / (1 + ((decimal)x.Customer.ShoppingCard.CardStatus / (decimal)100))).FirstOrDefault());
            }


            return mealsSum + drinksSum;
        }
        public async Task<int> FinishOrderAsync(string orderId)
        {
            var getOrder = await this.ServiceConnector.Orders.FindById(orderId);
            getOrder.HasPaid = true;

            await this.ServiceConnector.Orders.Update(getOrder);
            int res = await ServiceConnector.SaveChangesAsync();
            return res;
        }
        public async Task<OrderViewModel> GetOrderStatusAsync(string userId)
        {
            var customer = this.ServiceConnector.Customers.GetAll(x => x.UserId == userId).Result.FirstOrDefault();

            var order = await this.ServiceConnector.Context.Set<Order>().Include(x => x.OrderedMeals).ThenInclude(x => x.Meal).FirstOrDefaultAsync(x => x.HasPaid == true && x.CustomerId == customer.Id && x.isFinished == false);


            return MapperConfigurator.Mapper.Map<OrderViewModel>(order);
        }
        public async Task<int> AddItemToCartAsync(OrderDataViewModel model, string userId)
        {
            var customer = await ServiceConnector.Context.Set<Customer>().Include(x => x.ShoppingCard).FirstOrDefaultAsync(x => x.UserId == userId);
            var totalOrders = 0;
            if (customer != null)
            {

                var orders = ServiceConnector.Orders.GetAll(x => x.CustomerId == customer.Id).GetAwaiter().GetResult().Where(x => x.HasPaid == false);

                var meal = await ServiceConnector.Meals.GetAll(x => x.Id == model.MealId);

                if (orders.Count() > 0)
                {
                    if (model.isMeal)
                    {
                        totalOrders = orders.Count();
                        var lastOrder = orders.OrderByDescending(x => x.CreatedAt).First();
                        lastOrder.OrderedMeals.Add(new OrderMeals()
                        {
                            MealId = model.MealId,
                            Quantity = model.Quantity,
                            SubTotal = (model.Quantity * meal.FirstOrDefault().Price) / (1 + ((decimal)customer.ShoppingCard.CardStatus / 100))
                        });
                        var res = await ServiceConnector.Orders.Update(lastOrder);
                        //await OrderService.ServiceConnector.Orders.SaveChangesAsync();
                    }
                    else
                    {
                        totalOrders = orders.Count();
                        var lastOrder = orders.OrderByDescending(x => x.CreatedAt).First();
                        var drink = await ServiceConnector.Drinks.GetAll(x => x.Id == model.DrinkId);

                        lastOrder.OrderDrinks.Add(new OrderDrinks()
                        {
                            DrinkId = model.DrinkId,
                            Quantity = model.Quantity,
                            SubTotal = (model.Quantity * drink.FirstOrDefault().Price) / (1 + ((decimal)customer.ShoppingCard.CardStatus / 100))
                        });
                        var res = await ServiceConnector.Orders.Update(lastOrder);
                    }

                }
                else
                {
                    if (model.isMeal)
                    {
                        var newMeal = await ServiceConnector.Meals.GetAll(x => x.Id == model.MealId);
                        await ServiceConnector.Orders.Add(new Order()
                        {
                            CustomerId = customer.Id,
                            HasPaid = false,
                            OrderComment = model.Comment,
                            OrderedMeals = new List<OrderMeals>()
                       {
                           new OrderMeals()
                           {
                               MealId=model.MealId,
                               Quantity=model.Quantity,
                               SubTotal=(model.Quantity*meal.FirstOrDefault().Price)/(1+((decimal)customer.ShoppingCard.CardStatus/100))
                           }
                       }
                        });
                        totalOrders = ServiceConnector.Orders.GetAll(x => x.CustomerId == customer.Id).GetAwaiter().GetResult().Where(x => x.HasPaid == false).Count();
                    }
                    else
                    {
                        var drink = await ServiceConnector.Drinks.GetAll(x => x.Id == model.DrinkId);
                        await ServiceConnector.Orders.Add(new Order()
                        {
                            CustomerId = customer.Id,
                            HasPaid = false,
                            OrderComment = model.Comment,
                            OrderDrinks = new List<OrderDrinks>()
                       {
                           new OrderDrinks()
                           {
                               DrinkId=model.DrinkId,
                               Quantity=model.Quantity,
                               SubTotal=(model.Quantity*drink.FirstOrDefault().Price)/(1+((decimal)customer.ShoppingCard.CardStatus/100))
                           }
                       }
                        });
                        totalOrders = ServiceConnector.Orders.GetAll(x => x.CustomerId == customer.Id).GetAwaiter().GetResult().Where(x => x.HasPaid == false).Count();
                    }

                }
                return totalOrders;
            }
            return totalOrders;
        }
    }
}
