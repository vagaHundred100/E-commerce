using ECommerceApp.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;

namespace ECommerceApp.Domain.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}