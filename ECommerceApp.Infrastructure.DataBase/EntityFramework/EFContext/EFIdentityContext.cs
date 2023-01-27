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
        public DbSet<CategoryType> CategoryTypes { get; set; }
        public DbSet<Variation> Variations { get; set; }
        public DbSet<VariationType> VariationTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//keys of Identity tables are mapped in OnModelCreating method of IdentityDbContext
            modelBuilder.Entity<CategoryType>()
                .HasMany(c => c.Children)
                .WithOne(c => c.Parent)
                .HasForeignKey(p => p.ParentId);

            modelBuilder.SeedDeafultData();
        }
    }
}