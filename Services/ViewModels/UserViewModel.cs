using Services.Interfaces;

namespace Services.ViewModels
{
    public class UserViewModel:IBaseViewModel
    {
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Id { get; set; }
    }
}