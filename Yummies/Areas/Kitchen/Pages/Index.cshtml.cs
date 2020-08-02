using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Services.Implementations;
using Services.Interfaces;
using Services.ViewModels;

namespace Yummies.Areas.Kitchen.Pages
{
    //[Authorize(Roles ="Admin,Seller,Cheff")]
    public class IndexModel : PageModel
    {
        public ILogger<IndexModel> Logger { get; set; }
        public KitchenService Service { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        [BindProperty]
        public string OrderId { get; set; }
        public IndexModel(ILogger<IndexModel> logger, KitchenService service)
        {
            Logger = logger;
            Service = service;
        }
        public async Task OnGet()
        {
            Orders = await Service.GetAllOrdersAsync();

        }
    }
}
