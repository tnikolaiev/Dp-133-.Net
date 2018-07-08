using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ras.BLL;
using Ras.BLL.Implementation;
using Ras.BLL.Implementation.Proxies.Logging;
using Ras.DAL;
using Ras.DAL.Implementation;
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
            services.AddTransient<IUnitOfWork>
                (s => new EFUnitOfWork("Server = localhost;user id = ras;database = ss_ps_db;Pwd = 1111;persistsecurityinfo = True;"));


            services.AddTransient<IStudentService>(s =>
            {
                var uow = s.GetService<IUnitOfWork>();
                var ss = new StudentService(uow);
                var logger = s.GetService<ILogger<StudentServiceLogProxy>>();

                return new StudentServiceLogProxy(ss, logger);
            });

            services.AddTransient<IGroupService>(s =>
            {
                var uow = s.GetService<IUnitOfWork>();
                var gs = new GroupService(uow);
                var logger = s.GetService<ILogger<GroupServiceLogProxy>>();

                return new GroupServiceLogProxy(gs, logger);
            });

            services.AddTransient<IDictionariesGroupService>(s =>
            {
                var uow = s.GetService<IUnitOfWork>();
                var gs = new DictionariesGroupService(uow);
                var logger = s.GetService<ILogger<DictionariesGroupServiceLogProxy>>();

                return new DictionariesGroupServiceLogProxy(gs, logger);
            });

            services.AddTransient<IDictionariesStudentService>(s =>
            {
                var uow = s.GetService<IUnitOfWork>();
                var ss = new DictionariesStudentService(uow);
                var logger = s.GetService<ILogger<DictionariesStudentServiceLogProxy>>();

                return new DictionariesStudentServiceLogProxy(ss, logger);
            });

            services.AddTransient<IDictionariesFeedbackService>(s =>
            {
                var uow = s.GetService<IUnitOfWork>();
                var fs = new DictionariesFeedbackService(uow);
                var logger = s.GetService<ILogger<DictionariesFeedbackServiceLogProxy>>();

                return new DictionariesFeedbackServiceLogProxy(fs, logger);
            });

            services.AddTransient<IGroupService, GroupService>();

            services.AddTransient<IDictionariesGroupService, DictionariesGroupService>();
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}));
            services.AddScoped<Filters.LoggerFilterAttribute>();
            services.AddScoped<Filters.CustomExeptionFilterAttribute>();
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
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    "spa-fallback",
                    new {controller = "Swagger", action = "Index"});
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "App"));
        }
    }
}