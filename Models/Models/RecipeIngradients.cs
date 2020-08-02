using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class RecipeIngradients:BaseEntity
    {
        public string RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public string IngradientId { get; set; }
        public Ingradient Ingradient { get; set; }
        public int IngradientQuantity { get; set; }
    }
}
