using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class PaginationService<T>:IPaginationService<T> where T:IBaseViewModel
    {
        public List<T> GetPaginatedResult(List<T> data,int currentPage, int pageSize = 10)
        {
            return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

    }
}
