using E_CommerceApp.JwtSetup;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Infrastructure.DataBase.EntityFramework.EFContext;
using ECommerceApp.Services.UserAccountService.Identity.Concrete;
using ECommerceApp.Services.UserAccountService.Services.Abstract;
using ECommerceApp.Services.UserAccountService.Services.Concrete;
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

            string conn = Configuration.GetConnectionString("Default");
            services.AddDbContext<EFIdentityContext>(options => options.UseSqlServer(conn, b => b.MigrationsAssembly("E-CommerceApp")));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<EFIdentityContext>();

            services.Configure<JwtOptions>(Configuration.GetSection("JWTOptions"));
            JwtOptions jwtSettings = Configuration.GetSection("JWTOptions").Get<JwtOptions>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IAccountService, AccountService>();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
