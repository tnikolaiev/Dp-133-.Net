using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ras.BLL;
using Ras.BLL.DTO;
using Ras.DAL.Entity;
using Ras.Infastructure;
using Ras.Web.Filters;
using Ras.Web.Models;
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvcCore().AddApiExplorer();

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/dist"; });

            ServiceBinder.BindServices(
                services, "Server = localhost;user id = ras;database = ss_ps_db;Pwd = 1111;persistsecurityinfo = True;");

            Bootstrapper.Execute(services);

            services.AddScoped<LoggerFilterAttribute>();
            services.AddScoped<CustomExeptionFilterAttribute>();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}));

            MappingBootstrapper.RegisterMapper<History, GroupHistoryDTO>(services);
            MappingBootstrapper.RegisterMapper<GroupHistoryDTO, GroupHistoryViewModel>(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions { HotModuleReplacement = true });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "App"));

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer("start");
                }
            });
        }
    }
}