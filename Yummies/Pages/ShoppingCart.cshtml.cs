using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Interfaces;
using Models.Models;
using Models.Models.IdentityModels;
using Services.Implementations;
using Services.ViewModels;

namespace Yummies.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private OrderService OrderService;
        private UserManager<User> _userManager;
        private string userId;

        [BindProperty]
        public ICollection<OrderViewModel> Orders { get; set; }
        [BindProperty]
        public decimal Total { get; set; }
        public ShoppingCartModel(OrderService service, UserManager<User> userManager)
        {
            OrderService = service;
            _userManager = userManager;
        }
        public async Task OnGetAsync()
        {
            userId = _userManager.GetUserId(User);
            Orders = await OrderService.GetNotFinishedOrders(userId);
            Total = await OrderService.TotalSum(userId);

        }
        public async Task OnGetDeleteOrder(string id)
        {
           await OrderService.ServiceConnector.Orders.Remove(id);
        }
        public async Task OnGetDeleteMealOrder(string id)
        {
            await OrderService.ServiceConnector.OrderMeals.Remove(id);
        }

        public async Task<ActionResult> OnPost(OrderDataViewModel model)
        {
            if (model.MealId==null)
            {
                return null;
            }
            userId = _userManager.GetUserId(User);
            var customer = OrderService.ServiceConnector.Customers.GetAll(x=>x.UserId==userId).Result.FirstOrDefault();
            var totalOrders = 0;
            if (customer!=null)
            {

                var orders = OrderService.ServiceConnector.Orders.GetAll(x => x.CustomerId == customer.Id).Result.Where(x => x.HasPaid == false);
                totalOrders = orders.Count();

                if (orders.Count() > 0)
                {
                    var lastOrder = orders.OrderByDescending(x => x.CreatedAt).First();
                    lastOrder.OrderedMeals.Add(new OrderMeals()
                    {
                        MealId = model.MealId,
                        Quantity = model.Quantity,

                    });
                    await OrderService.ServiceConnector.Orders.Update(lastOrder);
                    await OrderService.ServiceConnector.Orders.SaveChangesAsync();
                }
                else
                {
                    await OrderService.ServiceConnector.Orders.Add(new Order()
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

                           }
                       }
                    });
                   
                }
               
            }

            return Partial("_Cart", totalOrders);
           
        }
        
    }
}
