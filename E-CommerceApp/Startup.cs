using E_CommerceApp.JwtSetup;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Repository;
using ECommerceApp.Infrastructure.DataBase.EntityFramework.EFContext;
using ECommerceApp.Infrastructure.DataBase.EntityFramework.EFRepository;
using ECommerceApp.Services.CategoryTypeService.Services.Concrete;
using ECommerceApp.Services.UserAccountService.Identity.Concrete;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using ECommerceApp.Services.UserAccountService.Services.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace E_CommerceApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);//You can set Time   
            });
            string conn = Configuration.GetConnectionString("Default");
            services.AddDbContext<EFIdentityContext>(options => options.UseSqlServer(conn, b => b.MigrationsAssembly("E-CommerceApp")));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<EFIdentityContext>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));
            JwtOptions jwtSettings = Configuration.GetSection("JwtOptions").Get<JwtOptions>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICategoryTypeService, CategoryTypeService>();
            services.AddScoped<ICategoryTypeRepository, EFCategoryTypeRepository>();
            services.AuthenticationJwtSettings(jwtSettings);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
