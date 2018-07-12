using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ras.BLL;
using Ras.BLL.DTO;
using Ras.BLL.Implementation;
using Ras.BLL.Implementation.Proxies.Logging;
using Ras.DAL;
using Ras.DAL.Implementation;
using Ras.Infastructure.Mapping;
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

            services.AddTransient<IUnitOfWork>
                (s => new EFUnitOfWork("Server = localhost;user id = ras;database = ss_ps_db;Pwd = 1111;persistsecurityinfo = True;"));

            var sp = services.BuildServiceProvider();
            var uow = sp.GetService<IUnitOfWork>();

            Ras.BLL.Bootstrapper.Execute(services);

            services.AddTransient<IStudentService>(s =>
            {
                var ss = new StudentService(uow);
                var logger = s.GetService<ILogger<StudentServiceLogProxy>>();

                return new StudentServiceLogProxy(ss, logger);
            });

            services.AddTransient<IGroupService>(s =>
            {
                var gs = new GroupService(uow);
                var logger = s.GetService<ILogger<GroupServiceLogProxy>>();

                return new GroupServiceLogProxy(gs, logger);
            });

            services.AddTransient<IDictionariesGroupService>(s =>
            {
                var dgs = new DictionariesGroupService(uow);
                var logger = s.GetService<ILogger<DictionariesGroupServiceLogProxy>>();

                return new DictionariesGroupServiceLogProxy(dgs, logger);
            });

            services.AddTransient<IDictionariesStudentService>(s =>
            {
                var dss = new DictionariesStudentService(uow);
                var logger = s.GetService<ILogger<DictionariesStudentServiceLogProxy>>();

                return new DictionariesStudentServiceLogProxy(dss, logger);
            });

            services.AddTransient<IDictionariesFeedbackService>(s =>
            {
                var dfs = new DictionariesFeedbackService(uow);
                var logger = s.GetService<ILogger<DictionariesFeedbackServiceLogProxy>>();

                return new DictionariesFeedbackServiceLogProxy(dfs, logger);
            });

            services.AddScoped<Ras.Web.Filters.LoggerFilterAttribute>();
            services.AddScoped<Ras.Web.Filters.CustomExeptionFilterAttribute>();

            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" }));

            Ras.Infastructure.MappingBootstrapper.RegisterMapper<Ras.DAL.Entity.History, GroupHistoryDTO>(services);
            Ras.Infastructure.MappingBootstrapper.RegisterMapper<GroupHistoryDTO, GroupHistoryViewModel>(services);
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
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
