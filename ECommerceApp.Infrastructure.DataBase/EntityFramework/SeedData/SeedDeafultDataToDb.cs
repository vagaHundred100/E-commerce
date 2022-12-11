using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ECommerceApp.Infrastructure.DataBase.EntityFramework.SeedData
{
    public static class SeedDeafultDataToDb
    {
        
        private static List<AppRole> qmsIdentityRoles = new List<AppRole>()
        {
            new AppRole {Id = 1, Name = "ADMIN", NormalizedName = "ADMIN"}        
        };
        private static List<AppUser> usersQms = new List<AppUser>()
        {
            new AppUser
            {
                Id = 1,
                UserName = "admin",            
                Status = EntityStatus.Active,
                Email = "ECommerceApp@ECommerceApp.net",
                NormalizedEmail = "qms@bestcomp.net",
                EmailConfirmed = false,
                NormalizedUserName = "ADMIN",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin777"),
                SecurityStamp = string.Empty,
            }
        };
        private static List<IdentityUserRole<int>> IdentityUserRoles = new List<IdentityUserRole<int>>()
        {
            new IdentityUserRole<int>{ RoleId= 1, UserId= 1 }
        };
       
        public static void SeedDeafultData(this ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<AppRole>().HasData(qmsIdentityRoles);
            modelBuilder.Entity<AppUser>().HasData(usersQms);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(IdentityUserRoles);       
        }
    }
}
