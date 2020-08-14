using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Implementations;
using Services.ViewModels;

namespace Yummies.Areas.Admin.Pages
{
    [Authorize(Roles ="ADMIN")]
   
    public class IndexModel : PageModel
    {
        private AdminService adminService;
        private PaginationService<SoldProductsViewModel> PaginationService;

        [BindProperty]
        public int TotalNewUsers { get; set; }
        [BindProperty]
        public int TotalDailyOrders { get; set; }
        [BindProperty]
        public decimal TotalDayIncomes { get; set; }
        [BindProperty]
        public List<IncomesViewModel> TotalMonthIncomes { get; set; }
        [BindProperty]
        public SelectList SelectList { get; set; }

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 10;
        [BindProperty]
        public List<PaginateViewModel> SoldProducts { get; set; }




        public IndexModel(AdminService service, PaginationService<SoldProductsViewModel> paginationService)
        {
            adminService = service;
            PaginationService = paginationService;
         
        }
        public async Task<IActionResult> OnGet()
        {
            TotalNewUsers =await adminService.GetNewClients();
            TotalDailyOrders = await adminService.GetTotalDailyOrders();
            TotalDayIncomes = await adminService.GetDailyIncomes();
            TotalMonthIncomes = await adminService.GetByMonthIncomes();

            SelectList = new SelectList(TotalMonthIncomes.Select(x => new {Id=x.MonthModel.MonthId,Name=x.MonthModel.Month }),"Id","Name");
            SoldProducts = PaginationService.GetPaginatedResult(await adminService.GetByDateIncomes(DateTime.UtcNow.Date.ToString()), 1, PageSize);
            Count = PaginationService.TotalSalesCount;
            return Page();
        }
        public async Task<IActionResult> OnGetDailySales(string date, int selectedPage=1)
        {
            
            if (date==null)
            {
                return Page();
            }
            if (date!=null)
            {
                SoldProducts = PaginationService.GetPaginatedResult(await adminService.GetByDateIncomes(date), selectedPage , PageSize);
                Count = PaginationService.TotalSalesCount;
            }
           

            return Partial("_SalesByDate",new PaginationData() { Count=TotalPages,Products=SoldProducts});
        }

    }
    public class PaginationData
    {
        public List<PaginateViewModel> Products { get; set; }
        public int Count { get; set; }
    }
}
