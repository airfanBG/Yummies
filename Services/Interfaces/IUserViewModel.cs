using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IUserViewModel:IBaseViewModel
    {
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string UserName { get; set; }
        public string Id { get; set; }
    }
}
