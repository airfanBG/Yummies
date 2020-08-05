using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Interfaces
{
    public abstract class BaseEntity:Entity<string>,IAuditInfo
    {
        public BaseEntity()
        {
            base.Id = Guid.NewGuid().ToString();
        }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
