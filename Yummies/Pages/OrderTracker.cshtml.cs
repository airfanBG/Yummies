using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.Models;
using Models.Models.IdentityModels;
using Services.Implementations;
using Services.ViewModels;

namespace Yummies.Pages
{
    public class OrderTrackerModel : PageModel
    {
        public OrderViewModel Order{ get; set; }
        private OrderService OrderService { get; }
        private UserManager<User> UserManager { get; }
        public OrderTrackerModel(OrderService service, UserManager<User> userManager)
        {
            OrderService = service;
            UserManager = userManager;
        }
        public async Task OnGet()
        {
            Order =await OrderService.GetOrderStatusAsync(UserManager.FindByNameAsync(User.Identity.Name).Result.Id);
        }
    }
}