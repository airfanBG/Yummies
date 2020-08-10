using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPaginationService<T> where T:IBaseViewModel
    {
        List<T> GetPaginatedResult(List<T> data,int currentPage, int pageSize = 10);
       
    }
}
