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
        private ServiceConnector ServiceConnector;
        private UserManager<User> _userManager;
        private string userId;

        [BindProperty]
        public ICollection<OrderViewModel> Orders { get; set; }
        [BindProperty]
        public decimal Total { get; set; }
        public ShoppingCartModel(ServiceConnector service, UserManager<User> userManager)
        {
            ServiceConnector = service;
            _userManager = userManager;
        }
        public async Task OnGetAsync()
        {
            //userId = _userManager.GetUserId(User);
            //Orders = await ServiceConnector.GetNotFinishedOrders(userId);
            //Total = await ServiceConnector.TotalSum(userId);
            
        }
        public async Task OnGetDelete(string id)
        {
          // await ServiceConnector.Remove(id);
        }
        public async Task<ICollection<OrderViewModel>> GetNotFinishedOrders(string userId)
        {
            //var orders = await Services.Implementations.ServiceConnector.Context.Set<Order>().Include((object x) => x.Customer).Include((object x) => x.OrderedMeals).ThenInclude((object x) => x.Meal).Where((object x) => x.Customer.UserId == userId).Where((object x) => x.HasPaid == false).ToListAsync();
            //var result = MapperConfigurator.Mapper.Map<List<OrderViewModel>>(orders);
            // return result;
            return null;
        }
       
        public async Task<decimal> TotalSum(string clientId)
        {
            //decimal res = await ServiceConnector.Context.Set<Order>()
            //    .Where(x => x.CustomerId == clientId && x.HasPaid == false)
            //    .Select(x => x.OrderedMeals.Sum(p => p.Meal.Price) / (1 + ((decimal)x.Customer.ShoppingCard.CardStatus / (decimal)100)))
            //    .FirstOrDefaultAsync();
            //return res;
            return 0;
        }
        public async Task<int> FinishOrder(string orderId)
        {

            //var getOrder = await this.ServiceConnector.Orders.FindById(orderId);
            //getOrder.HasPaid = true;

            //await this.ServiceConnector.Orders.Update(getOrder);
            //int res = await Services.Implementations.ServiceConnector.SaveChangesAsync();
            //return res;
            return 0;
        }
    }
}
