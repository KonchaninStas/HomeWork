using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Control_V_3.Models;
using Control_V_3.Models.FakeBooks;
using Control_V_3.Models.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
            services.AddTransient<IBookRepository, EFBooksRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
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
               

                //routes.MapRoute(
                //    name: "pagination",
                //    template: "Books/Page{page}",
                //    defaults: new { Controller = "Book", action = "List" });
                //routes.MapRoute(
                //name: "default",
                //template: "{controller=Book}/{action=List}/{id?}");
            });
            //app.UseMvc(routes => {
            //    routes.MapRoute(
            //        name: "pagination",
            //        template: "Books/Page{page}",
            //        defaults: new { Controller = "Book", action = "List" });
            //    routes.MapRoute(
            //    name: "default",
            //    template: "{controller=Book}/{action=List}/{id?}");
            //});
        }
    }
}
