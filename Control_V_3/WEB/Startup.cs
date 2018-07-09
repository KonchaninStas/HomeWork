using Control_V_3.Models;
using Control_V_3.Models.EFRepository;
using Control_V_3.Models.FakeRepository;
using Control_V_3.Models.Repository;
using DataBase;
using DataBaseIdentityLibrary;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Control_V_3
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
            services.AddDbContext<ApplicationContext>();
            services.AddDbContext<AppIdentityDbContext>();
            services.AddIdentity<IdentityUser, IdentityRole>()
        .AddEntityFrameworkStores<AppIdentityDbContext>()
        .AddDefaultTokenProviders();
            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
            services.AddTransient<IBookRepository, EFBooksRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseIdentity();
            app.UseAuthentication();
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: null,
                    template: "{category}/Page{page:int}",
                    defaults: new { Controller = "Book", action = "List" }
                    );
                routes.MapRoute(
                    name: null,
                    template: "Page{page:int}",
                    defaults: new { Controller = "Book", action = "List", page = 1 }
                    );
                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { Controller = "Book", action = "List", page = 1 }
                    ); routes.MapRoute(
                    name: null,
                    template:"" ,
                    defaults: new { Controller = "Book", action = "List", page = 1 }
                    );
                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}/{id?}"
                    );
                //FakeIdentity.EnsurePopulated(app);
            });
        }
    }
}
