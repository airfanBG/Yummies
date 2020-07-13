using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Models.Models
{
    public class Menu:BaseEntity
    {
        public ICollection<Meal> Meals { get; set; }
    }
}
