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
        private static List<AppUser> eCommerceUser = new List<AppUser>()
        {
            new AppUser
            {
                Id = 1,
                UserName = "admin",            
                Status = EntityStatus.Active,
                Email = "ECommerceApp@ECommerceApp.net",
                NormalizedEmail = "qms@bestcomp.net",
                EmailConfirmed = false,             
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin777"),
                SecurityStamp = string.Empty,
            }
        };
        private static List<IdentityUserRole<int>> IdentityUserRoles = new List<IdentityUserRole<int>>()
        {
            new IdentityUserRole<int>{ RoleId= 1, UserId= 1 },
            new IdentityUserRole<int>{ RoleId= 2, UserId= 1 },
            new IdentityUserRole<int>{ RoleId= 3, UserId= 1 },
            new IdentityUserRole<int>{ RoleId= 4, UserId= 1 },
            new IdentityUserRole<int>{ RoleId= 5, UserId= 1 },
            new IdentityUserRole<int>{ RoleId= 6, UserId= 1 },
            new IdentityUserRole<int>{ RoleId= 7, UserId= 1 },
            new IdentityUserRole<int>{ RoleId= 2, UserId= 2 },
            new IdentityUserRole<int>{ RoleId= 3, UserId= 3 },
            new IdentityUserRole<int>{ RoleId= 4, UserId= 4 },
            new IdentityUserRole<int>{ RoleId= 5, UserId= 5 },
            new IdentityUserRole<int>{ RoleId= 6, UserId= 6 },
            new IdentityUserRole<int>{ RoleId= 7, UserId= 7 },
        };
       
        public static void SeedDeafultData(this ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<AppRole>().HasData(qmsIdentityRoles);
            modelBuilder.Entity<AppUser>().HasData(eCommerceUser);
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(IdentityUserRoles);       
        }
    }
}
