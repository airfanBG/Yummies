using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Models.Models
{
    public class Menu:IBaseEntity
    {
        public string Id { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
