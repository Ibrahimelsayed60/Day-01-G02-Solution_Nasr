using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Structure
{
    //class ProductsController : Controller
    //{
    //    public ProductService _productService { get; set; }

    //    public ProductsController(ProductService productService)
    //    {
    //        _productService = productService;
    //    }
    //    // Action: baseUrl/Products/GetProduct?id=10
    //    public IActionResult GetProduct(int id)
    //    {
    //        //return View("ProductDetails"); Returns view named ProductDetails
    //        var product = _productService.GetProductById(id);
    //        return View(product); // Return View named GetProduct (like name of action)
    //    }
    //}

    //class ProductService
    //{
    //    public ProductRepository _productRepository;
    //    public CategoryRepository _categoryRepository;

    //    public ProductService(ProductRepository productRepository, CategoryRepository categoryRepository)
    //    {
    //        _productRepository = productRepository;
    //        _categoryRepository = categoryRepository;
    //    }
    //    public Product GetProductById(int id)
    //    {
    //        // Business Logic
    //        var categories = _categoryRepository.GetAll().FindAll(c=>c.IsOutOfStock == true);

    //        var product = _productRepository.Get(id);

    //        if (categories.Contains(product.Category))
    //            product = null;

    //        return product;

    //    }
    //}

    //class ProductRepository
    //{
    //    private ApplicationDbContext _dbContext;

    //    public ProductRepository(ApplicationDbContext dbContext) // Ask CLR for creating object from DbContext
    //    {
    //        _dbContext = dbContext;
    //    }
    //    public Product Get(int id)
    //    {
    //        return _dbContext.Products.Find(id); 
    //    }
    //}

    //class CategoryRepository
    //{
    //    private ApplicationDbContext _dbContext;

    //    public CategoryRepository(ApplicationDbContext dbContext)
    //    {
    //        _dbContext = dbContext;
    //    }
    //    public List<Category> GetAll()
    //    {
    //        return _dbContext.Categories.ToList();
    //    }
    //}

    //class ApplicationDbContext:DbContext
    //{
    //    public ApplicationDbContext(DbContextOptions options):base()
    //    {

    //    }
    //    public DbSet<Product> Products { get; set; }
    //    public DbSet<Category> Categories { get; set; }

    //}
    //class Product
    //{
    //    public int Id { get; set; }

    //    public string? Name { get; set; }

    //    public string? Description { get; set; }

    //    public decimal UnitPrice { get; set; }

    //    public Category Category { get; set; }
    //}
    //class Category
    //{
    //    public int Id { get; set; }

    //    public string? Name { get; set; }

    //    public bool IsOutOfStock { get; set; }
    //}


    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Add<ApplicationDbContext>();
            //services.AddTransient<ApplicationDbContext>();
            //services.AddScoped<ApplicationDbContext>(option =>
            //{
            //    option.UseSqlServer("ConnectionString");
            //});
            //services.AddSingleton<ApplicationDbContext>();
            //services.AddScoped<ProductRepository>();
            //services.AddScoped<CategoryRepository>();
            //services.AddScoped<ProductService>();
            //services.AddControllers();

            services.AddControllersWithViews();

            //services.AddRazorPages();

            //services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            //if (env.IsStaging())
            //if (env.IsProduction())
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Home/Error/");
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGet("/Hamda", async context =>
                {
                    await context.Response.WriteAsync("Hello Hamda!");
                });

                endpoints.MapControllerRoute(
                    name: default,
                    pattern:"{controller}/{action}/{id?}"
                    );
            });
        }
    }
}
