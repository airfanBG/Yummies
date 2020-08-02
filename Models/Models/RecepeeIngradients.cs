using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models
{
    public class RecepeeIngradients:BaseEntity
    {
        public string RecepeeId { get; set; }
        public Recepee Recepee { get; set; }
        public string IngradientId { get; set; }
        public Ingradient Ingradient { get; set; }
        public int IngradientQuantity { get; set; }
    }
}
