using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Structure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webApplicationBuilder = WebApplication.CreateBuilder();

            #region Configure Services Method in .NET 5
            webApplicationBuilder.Services.AddControllersWithViews(); 
            #endregion

            var app = webApplicationBuilder.Build();

            #region Configure Method in .Net 5
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Home/Error/");
            }

            app.UseRouting();


            app.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            app.MapGet("/Hamda", async context =>
            {
                await context.Response.WriteAsync("Hello Hamda!");
            });

            app.MapControllerRoute(
                name: default,
                pattern: "{controller}/{action}/{id?}"
            ); 
            #endregion

            app.Run();

            //CreateHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
