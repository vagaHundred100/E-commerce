using ECommerceApp.Domain.Entities;
using ECommerceApp.Infrastructure.DataBase.EntityFramework.SeedData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Infrastructure.DataBase.EntityFramework.EFContext
{
    public class EFIdentityContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public EFIdentityContext(DbContextOptions<EFIdentityContext> options) : base(options)
        {
            //Database.Migrate();
            //Database.EnsureDeleted();   // удаляем бд со старой схемой
            //Database.EnsureCreated();   // создаем бд с новой схемой
        }

        #region DbSet's
        public DbSet<Announcement> Announcements { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//keys of Identity tables are mapped in OnModelCreating method of IdentityDbContext
            modelBuilder.SeedDeafultData();
        }
    }
}