using Microsoft.AspNetCore.Identity;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.IdentityModels
{
    public class UserRole : IdentityRole, IAuditInfo
    {
        public UserRole()
            : this(null)
        {
        }

        public UserRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
