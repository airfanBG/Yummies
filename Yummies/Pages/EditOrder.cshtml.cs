using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Newtonsoft.Json;
using Services.Implementations;
using Services.Mapping;
using Services.ViewModels;

namespace Yummies.Pages
{
    public class EditOrderModel : PageModel
    {
        [BindProperty]
        public OrderMealsViewModel OrderedMeal { get; set; }
        private OrderService OrderService { get; }
        public EditOrderModel(OrderService service)
        {
            OrderService = service;
        }
        public void OnGet(string model)
        {
            OrderedMeal = JsonConvert.DeserializeObject<OrderMealsViewModel>(model);
         
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            var res = MapperConfigurator.Mapper.Map<OrderMeals>(OrderedMeal);

            var oldModel = await OrderService.ServiceConnector.Context.Set<OrderMeals>().Include(x => x.Meal).Include(x=>x.Order).ThenInclude(x=>x.Customer).ThenInclude(x=>x.ShoppingCard).FirstOrDefaultAsync(x=>x.Id==OrderedMeal.Id);
            oldModel.Quantity = OrderedMeal.Quantity;
            oldModel.SubTotal = (res.Quantity * oldModel.Meal.Price) / (1 + ((decimal)oldModel.Order.Customer.ShoppingCard.CardStatus / 100));
            var status=await OrderService.ServiceConnector.OrderMeals.Update(oldModel);
            if (status==1)
            {
                return RedirectToPage("ShoppingCart");
            }
            return Page();
        }
    }
}