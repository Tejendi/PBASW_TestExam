using System.Buffers;
using ImagePortal.Core.Department;
using ImagePortal.Core.DepartmentImages;
using ImagePortal.Core.Interfaces;
using ImagePortal.DepartmentImages;
using ImagePortal.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ImagePortal
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
            services.AddTransient<IDepartmentImageRepository, DepartmentImageRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddSingleton<IDepartmentImageService, DepartmentImageService>();
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddMvc(options =>
           {
               options.OutputFormatters.Add(new JsonOutputFormatter(new JsonSerializerSettings()
               {
                   ContractResolver = new CamelCasePropertyNamesContractResolver()
               }, ArrayPool<char>.Shared));
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
