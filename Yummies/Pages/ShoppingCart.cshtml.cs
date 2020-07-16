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
        private OrderService _service;
        private UserManager<User> _userManager;
        private string userId;

        [BindProperty]
        public ICollection<OrderViewModel> Orders { get; set; }
        [BindProperty]
        public decimal Total { get; set; }
        public ShoppingCartModel(OrderService service, UserManager<User> userManager)
        {
            _service = service;
            _userManager = userManager;
        }
        public async Task OnGetAsync()
        {
            userId = _userManager.GetUserId(User);
            Orders = await _service.GetNotFinishedOrders(userId);
            Total = await _service.TotalSum(userId);
        }
        public async Task OnGetDelete(string id)
        {
           await _service.Remove(id);
        }
    }
}
