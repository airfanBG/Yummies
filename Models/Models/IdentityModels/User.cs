using Microsoft.AspNetCore.Identity;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models.Models.IdentityModels
{
    public class User: IdentityUser, IAuditInfo
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
