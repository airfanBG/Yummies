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
        List<SoldProductsViewModel> SoldProducts;




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
            
            return Page();
        }
        public async Task<IActionResult> OnGetDailySales(string date, int page)
        {
            if (date==null)
            {
                return Page();
            }
            if (SoldProducts==null)
            {
                SoldProducts = PaginationService.GetPaginatedResult(await adminService.GetByDateIncomes(date), CurrentPage, PageSize);
               
            }           

            return Partial("_SalesByDate",SoldProducts);
        }

    }
}
