using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.business.Abstract;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.business.Concrete;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data;
using BeyzaNurCansever.OneDrive.Masaüstü.YazLab1.ShopApp.ShopApp.Data.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopApp.Data.Abstract;
using ShopApp.Data.Concrete;

namespace ShopApp
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
            services.AddScoped<ILaptopService, LaptopManager>();
            services.AddScoped<ILaptopSiteRepository, EfCoreLaptopSiteRepository>();
            services.AddScoped<ILaptopRepository, EfCoreLaptopRepository>();
            services.AddControllersWithViews();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {


                endpoints.MapControllerRoute(
                    name: "compareproductlist",
                    pattern: "compare/products",
                    defaults: new { controller = "Compare", action = "List" }
                );
                endpoints.MapControllerRoute(
                    name: "compareproductfilter",
                    pattern: "compare/BrandFilterList",
                    defaults: new { controller = "Compare", action = "BrandFilterList" }
                );
                endpoints.MapControllerRoute(
                    name: "compareproductfilter",
                    pattern: "compare/OSFilterList/{filtername?}",
                    defaults: new { controller = "Compare", action = "OSFilterList" }
                );
                endpoints.MapControllerRoute(
                    name: "compareproductfilter",
                    pattern: "compare/ProcessorFilterList/{filtername?}",
                    defaults: new { controller = "Compare", action = "ProcessorFilterList" }
                );
                endpoints.MapControllerRoute(
                    name: "compareproductfilter",
                    pattern: "compare/ScreenFilterList/{filtername?}",
                    defaults: new { controller = "Compare", action = "ScreenFilterList" }
                );

                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search",
                    defaults: new { controller = "Compare", action = "Search" }
                );

                endpoints.MapControllerRoute(
                    name: "compareproductdetails",
                    pattern: "compare/products/details",
                    defaults: new { controller = "Compare", action = "Details" }
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
