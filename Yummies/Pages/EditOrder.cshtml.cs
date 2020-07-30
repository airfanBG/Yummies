using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Services.ViewModels;

namespace Yummies.Pages
{
    public class EditOrderModel : PageModel
    {
        [BindProperty]
        public OrderMealsViewModel OrderedMeal { get; set; }
        public void OnGet(string model)
        {
            OrderedMeal = JsonConvert.DeserializeObject<OrderMealsViewModel>(model);
         
        }
    }
}