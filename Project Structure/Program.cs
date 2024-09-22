using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Constraints;
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

            //webApplicationBuilder.Services.AddControllers(); // Register APIs required services (Controller Activation, Model binding, 

            //MvcViewFeaturesMvcCoreBuilderExtensions.AddViews();

            webApplicationBuilder.Services.AddControllersWithViews(); // Register MVC required services (Controller Activation, Model binding, 

            //webApplicationBuilder.Services.AddRazorPages(); // Register Razor pages required services ( Model binding, 

            //webApplicationBuilder.Services.AddMvc();
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

            // First type of segment: Static segment, you must write Hamda in url
            app.MapGet("/Hamda", async context =>
            {
                await context.Response.WriteAsync("Hello Hamda!");
            });
            // Second type of segment: Variable segment
            //app.MapGet("/{id:int}", async context =>
            //app.MapGet("/{id:alpha}", async context =>
            //app.MapGet("/{id}", async context =>
            //{
            //    await context.Response.WriteAsync("Hello hazam!");
            //});

            app.MapGet("/xx{id:alpha}", async context =>
            {
                await context.Response.WriteAsync($"Id: {context.Request.RouteValues["id"]}");
            });

            app.MapControllerRoute(
                name: default,
                //pattern: "{controller}/{action}/{id?}"
                pattern: "{controller=Movies}/{action=Index}/{id:int?}"
                //pattern: "{controller=Movies}/{action=Index}/{id:int?}/{name:alpha?}/{email:Regex()?}",
                //constraints: new {id = new IntRouteConstraint()}
            //pattern: "Hamda/{controller}/{action}/{id?}"
            //pattern: "Hamda/xx{controller}/{action}/{id?}"
            //pattern: "{action}/{controller}/{id?}"
                //defaults: new {controller = "Movies", action = "Index"}
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
