using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Models.Models;
using Services.Implementations;
using Services.Interfaces;
using Services.ViewModels;

namespace Yummies.Areas.Kitchen.Pages
{
    [Authorize(Roles ="Admin,Seller,Cheff")]
    public class IndexModel : PageModel
    {
        public ILogger<IndexModel> Logger { get; set; }
        public KitchenService Service { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        [BindProperty]
        public string OrderId { get; set; }
        [BindProperty]
        public string MealId { get; set; }

        [BindProperty]
        public string Comment { get; set; }

        [BindProperty(SupportsGet =true)]
        public List<Statuses> Statuses { get; set; }

        [BindProperty(SupportsGet =true)]
        public Statuses Status { get; set; }
        public IndexModel(ILogger<IndexModel> logger, KitchenService service)
        {
            Logger = logger;
            Service = service;

        }
        public async Task OnGet()
        {
            var statuses = Enum.GetValues(typeof(Statuses));

            Statuses = statuses.OfType<Statuses>().ToList();
            Orders = await Service.GetAllOrdersAsync(Status);
        }
        public async Task<IActionResult> OnPostStartAsync()
        {
            var res = await Service.StartMealPreparing(OrderId, MealId);

            return Partial("MealPreparing", res);
        }
        public async Task<IActionResult> OnPostRejectAsync()
        {
            var res = await Service.RejectMealPreparing(OrderId, MealId, Comment);
            if (res == 1)
            {
                return RedirectToPage("/Index");
            }
            return Content(res.ToString());
        }
    }
}
