using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPaginationService<T,Tout> where T: IInfrastructureViewModels where Tout: ICombinedRestaurantStatistics
    {
        List<Tout> GetPaginatedResult(List<T> data,int currentPage, int pageSize = 10);
       
    }
}
