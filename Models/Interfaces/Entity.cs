using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Interfaces
{
    public abstract class Entity<Tkey> where Tkey : class
    {
        [Key]
        public Tkey Id { get; set; }
       
    }
}
