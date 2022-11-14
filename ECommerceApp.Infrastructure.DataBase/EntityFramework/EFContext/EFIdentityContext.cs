using ECommerceApp.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infrastructure.DataBase.EntityFramework.EFContext
{
    public class EFIdentityContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public EFIdentityContext(DbContextOptions<EFIdentityContext> options) : base(options)
        {
            //Database.Migrate();
            //Database.EnsureDeleted();   // удаляем бд со старой схемой
            Database.EnsureCreated();   // создаем бд с новой схемой
        }
    }
}