using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Models.Models
{
    public class Menu: BaseEntity<string>
    {
        public string MenuName { get; set; }
        public string Image { get; set; }
        public ICollection<MenuMealCategory> MenuMealCategories { get; set; }
    }
}
