using Services.Interfaces;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class PaginationService<T>:IPaginationService<T> where T:IInfrastructureViewModels 
    {
        public int TotalSalesCount { get;private set; }
        public List<PaginateViewModel> GetPaginatedResult(List<T> data,int currentPage, int pageSize = 10)
        {
            var res = data.SelectMany(x => x.OrderMealsViews, (a, b) => new 
            {

                SoldProducts = a.OrderMealsViews.Select(z => new PaginateViewModel()
                {
                    CreatedAt = z.CreatedAt,
                    Id = z.Id,
                    Quantity = z.Quantity,
                    SubTotal = z.SubTotal,
                    Name=z.Meal.Name
                }).Union(a.OrderDrinksViewModels.Select(z => new PaginateViewModel()
                {
                    CreatedAt = z.CreatedAt,
                    Id = z.Id,
                    Quantity = z.Quantity,
                    SubTotal = z.SubTotal,
                    Name=z.Drink.Name
                })),

            }).FirstOrDefault();
            if (res!=null)
            {
                TotalSalesCount = res.SoldProducts.Count();

                return res.SoldProducts.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            }
            return new List<PaginateViewModel>();
           
        }
       
    }
}
