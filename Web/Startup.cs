using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Ras.Web
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
            services.AddMvc();
            services.AddMvcCore().AddApiExplorer();
            services.AddTransient<DAL.IUnitOfWork>
                (s => new DAL.Implementation.EFUnitOfWork("Server = localhost;user id = ras;database = ss_ps_db;Pwd = 1111;persistsecurityinfo = True;"));
            var sp = services.BuildServiceProvider();
            var uow = sp.GetService<DAL.IUnitOfWork>();
            services.AddTransient<BLL.IStudentService, BLL.Implementation.StudentService>();
            services.AddTransient<BLL.IDictionariesGroupService, BLL.Implementation.DictionariesGroupService>();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}));
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
                    defaults: new { controller = "Swagger", action = "Index" });
            });

            app.UseSwagger();
            app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json", "App"));
        }
    }
}
