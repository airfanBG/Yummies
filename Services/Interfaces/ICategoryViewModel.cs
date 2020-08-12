using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICategoryViewModel:IBaseViewModel
    {
        public string CategoryName { get; set; }
        public string Image { get; set; }
    }
}
