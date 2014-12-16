using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.Framework.DependencyInjection;
using ASP5AppWithEF7.Models;
using Microsoft.AspNet.Hosting;
using ASP5AppWithEF7.Services;
using Microsoft.AspNet.Routing;

namespace ASP5AppWithEF7
{
    public class Startup
    {
        public static  IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment hostingEnv)
        {
            Configuration = new Configuration().AddJsonFile("Config.json").AddEnvironmentVariables();
        }

        /// <summary>
        /// The below methods performs dependency injection
        /// for ProductDbContext and ProductService
        /// </summary>
        /// <param name="srvs"></param>
        public void ConfigureServices(IServiceCollection srvs)
        {
            //Entity Framework to use Sql Server
            srvs.AddEntityFramework().AddSqlServer().AddDbContext<ProductDbContext>();
            //MVC so that we can use MVC and Web API
            srvs.AddMvc();
            //The Dependency for the DbContext is added
            srvs.AddScoped<ProductDbContext, ProductDbContext>();

            srvs.AddScoped<IProductService, ProductService>();
        }

        //Configura the code for Mvc Startup
        public void Configure(IApplicationBuilder appBuilder)
        {
            appBuilder.UseMvc(r=>r.MapRoute(
                 name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "ProductMVC", action = "Index" }
                ));
        }
    }
}
