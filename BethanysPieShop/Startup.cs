using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using BethanysPieShop.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        //ctor DInjection -> configuration are being taken here
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Passing own context pipe and telling that we are using sql server
            // configuration taken from appsetting.json{name -> value}
            // add by add-> new item-> appsettings(ASP configuration file
            // will have deault connection
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            /*Since we need MockPieRepo from multiple location
            // we will provide it(MockRepository) to dependecy container
            // by registering following code
            //This exactly means whenever IPie would be required a MockPie instance would be returned
            //In term of lifetime whenever IPie requested 
            an instance of MockPieRepo is initialized and returned
            services.AddSingleton
            services.AddScoped
             * */
            services.AddTransient<IPieRepository, PieRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            //framework services dependency injection container
            services.AddMvc();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            /* to add custom routes
                template is because we want it to match the incoming request..
                can add multiple using routes.MapRoute function
             */
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                    );
            }
            );
            //app.UseMvcWithDefaultRoute();
            // Default route maps to {controller=Home}/{action=Index}/{id?}
            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });*/
        }
    }
}
