using Services.Interfaces;
using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class PaginationService<T,Tout>:IPaginationService<T, Tout> where T:IInfrastructureViewModels  where Tout: ICombinedRestaurantStatistics
    {
        public List<Tout> GetPaginatedResult(List<T> data,int currentPage, int pageSize = 10)
        {
            var rr = data.SelectMany(x => x.OrderMealsViews, (a, b) => new
            {
                SoldProducts = a.OrderMealsViews.Select(z => new PaginateViewModel()
                {
                    CreatedAt = z.CreatedAt,
                    Id = z.Id,
                    Quantity = z.Quantity,
                    SubTotal = z.SubTotal
                }).Union(a.OrderDrinksViewModels.Select(z => new PaginateViewModel()
                {
                    CreatedAt = z.CreatedAt,
                    Id = z.Id,
                    Quantity = z.Quantity,
                    SubTotal = z.SubTotal
                })),
                //SoldDrinks = a.OrderDrinksViewModels.Select(z => new PaginateViewModel()
                //{
                //    CreatedAt = z.CreatedAt,
                //    Id = z.Id,
                //    Quantity = z.Quantity,
                //    SubTotal = z.SubTotal
                //})
            }).FirstOrDefault();
            var t = data.Select(x => x.OrderDrinksViewModels.Select(z => new PaginateViewModel() { })).FirstOrDefault();
            var res = data.SelectMany(x => x.OrderDrinksViewModels, (a, b) => new PaginateViewModel()
            {
         
                //  CreatedAt=a.OrderDrinksViewModels.
            });
            return null;
            //return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

    }
}
