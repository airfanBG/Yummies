using Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPaginationService<T> where T: IInfrastructureViewModels
    {
        List<PaginateViewModel> GetPaginatedResult(List<T> data,int currentPage, int pageSize = 10);
       
    }
}
