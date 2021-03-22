using BlogSolutionSystem.Business.AutoMapper.Profiles;
using BlogSolutionSystem.Business.Extensions;
using BlogSolutionSystem.UI.AutoMapper.Profiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSolutionSystem.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddSession();
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ArticleProfile), typeof(UserProfile));
            services.LoadMyServices();
            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Admin/User/Login");
                opt.LogoutPath = new PathString("/Admin/User/Logout");
                opt.Cookie = new CookieBuilder
                {
                    Name = "BlogSolutionSystem",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict, //Sadece kendi sitemizden gelince iþlenmesi saglanacaktýr en güvenlisi 
                    SecurePolicy = CookieSecurePolicy.SameAsRequest // Bu ayar Always olmalýdýr yoksa baþýmýza iþ açabilir güvenlik açýgýdýr.

                };
                opt.SlidingExpiration = true;
                opt.ExpireTimeSpan = System.TimeSpan.FromDays(7);
                opt.AccessDeniedPath = new PathString("/Admin/User/AccessDenied");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=User}/{action=UserLogin}/{id?}"
                    );
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
