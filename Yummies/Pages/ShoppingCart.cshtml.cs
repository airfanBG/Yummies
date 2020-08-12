using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.Models;
using Models.Models.IdentityModels;
using Newtonsoft.Json;
using Services.Implementations;
using Services.Interfaces;
using Services.Mapping;
using Services.ViewModels;

namespace Yummies.Pages
{
    [Authorize]
    public class ShoppingCartModel : PageModel
    {
        private OrderService OrderService;
        private UserManager<User> _userManager;
        private string userId;

        [BindProperty]
        public List<OrderViewModel> Orders { get; set; }
        [BindProperty]
        public decimal Total { get; set; } = 0;
        [BindProperty(SupportsGet =true)]
        public string OrderId { get; set; }
        public ShoppingCartModel(OrderService service, UserManager<User> userManager)
        {
            OrderService = service;
            _userManager = userManager;
        }
        public async Task OnGetAsync()
        {
             userId = _userManager.GetUserId(User);
             Orders = await OrderService.GetNotFinishedOrdersAsync(userId);
             Total = await OrderService.TotalSumAsync();
           
        }
        public async Task OnGetDeleteOrder(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                await OrderService.ServiceConnector.Orders.Remove(id);
            }
        }
        public async Task<IActionResult> OnPostDeleteMealOrderAsync(string mealId, string orderId)
        {
            if (mealId==null||orderId==null)
            {
                return null;
            }
            var res = OrderService.ServiceConnector.OrderMeals.GetAll(x => x.MealId == mealId && x.OrderId == orderId).GetAwaiter().GetResult().FirstOrDefault();
         
            var status=await OrderService.ServiceConnector.OrderMeals.Remove(res.Id);

            var checkOrderedMealsInOrder =await OrderService.ServiceConnector.Orders.FindById(orderId);
            if (checkOrderedMealsInOrder.OrderedMeals.Count() == 0)
            {
                await OrderService.ServiceConnector.Orders.Remove(checkOrderedMealsInOrder.Id);
            }
            return Content(status.ToString());
        }

        public async Task<IActionResult> OnPost(OrderDataViewModel model)
        {
            if (model==null)
            {
                return null;
            }
            userId = _userManager.GetUserId(User);
            var totalOrders =await OrderService.AddItemToCartAsync(model, userId);


            return Partial("_Cart", totalOrders);
           
        }

        public async Task<IActionResult> OnPostShowEditOrderAsync(string mealId, string orderId)
        {
            userId = _userManager.GetUserId(User);
            Orders = await OrderService.GetNotFinishedOrdersAsync(userId);
            Total = await OrderService.TotalSumAsync();

            var orderMeal =await OrderService.ServiceConnector.OrderMeals.GetAll(x => x.MealId == mealId && x.OrderId==orderId);
          
            var res = MapperConfigurator.Mapper.Map<OrderMealsViewModel>(orderMeal.FirstOrDefault());
            var json = JsonConvert.SerializeObject(res);
            return RedirectToPage("EditOrder",new { model = json } );
        }
        public async Task<IActionResult> OnPostSubmitOrderAsync()
        {
            var res = await OrderService.FinishOrderAsync(OrderId);
            if (res==1)
            {
                return Page();
            }
            return Page();
        }
    }
}
