using ECommerceApp.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;

namespace ECommerceApp.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}