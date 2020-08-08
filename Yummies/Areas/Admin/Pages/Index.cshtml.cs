using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Implementations;
using Services.ViewModels;

namespace Yummies.Areas.Admin.Pages
{
    [Authorize(Roles ="ADMIN")]
   
    public class IndexModel : PageModel
    {
        private AdminService adminService;
        [BindProperty]
        public int TotalNewUsers { get; set; }
        [BindProperty]
        public int TotalDailyOrders { get; set; }
        [BindProperty]
        public decimal TotalDayIncomes { get; set; }
        [BindProperty]
        public List<IncomesViewModel> TotalMonthIncomes { get; set; }
        public IndexModel(AdminService service)
        {
            adminService = service;
        }
        public async Task<IActionResult> OnGet()
        {
            TotalNewUsers =await adminService.GetNewClients();
            TotalDailyOrders = await adminService.GetTotalDailyOrders();
            TotalDayIncomes = await adminService.GetDailyIncomes();
            TotalMonthIncomes = await adminService.GetMonthIncomes();
            return Page();
        }

    }
}
