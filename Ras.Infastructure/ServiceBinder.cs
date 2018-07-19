using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ras.BLL;
using Ras.BLL.Implementation;
using Ras.DAL;
using Ras.DAL.Implementation;
using Ras.Infastructure.BLL.Proxies.Logging;

namespace Ras.Infastructure
{
    public static class ServiceBinder
    {
        /// <summary>
        ///     Binds BLL services as one to one int Transient scope.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection" /> from ConfigureServices method.</param>
        /// <param name="connectionString">Connection string will be used to create UnitOfWork.</param>
        public static void BindServices(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUnitOfWork>
                (s => new EFUnitOfWork(connectionString));
//#if LOG_SERVICES
            BindServiceWithLoggingProxy<IStudentService, StudentService, StudentServiceLogProxy>(services);
            BindServiceWithLoggingProxy<IGroupService, GroupService, GroupServiceLogProxy>(services);
            BindServiceWithLoggingProxy<IDictionariesFeedbackService, DictionariesFeedbackService, DictionariesFeedbackServiceLogProxy>(services);
            BindServiceWithLoggingProxy<IDictionariesGroupService, DictionariesGroupService, DictionariesGroupServiceLogProxy>(services);
            BindServiceWithLoggingProxy<IDictionariesStudentService, DictionariesStudentService, DictionariesStudentServiceLogProxy>(services);
//#else
//            services.AddTransient<IStudentService, StudentService>();
//            services.AddTransient<IGroupService, GroupService>();
//            services.AddTransient<IDictionariesFeedbackService, DictionariesFeedbackService>();
//            services.AddTransient<IDictionariesGroupService, DictionariesGroupService>();
//            services.AddTransient<IDictionariesStudentService, DictionariesStudentService>();
//#endif
        }

        private static void BindServiceWithLoggingProxy<TService, TImplementation, TLogProxy>(IServiceCollection services)
            where TService : class
            where TImplementation : Service, TService
            where TLogProxy : ServiceLogProxy<TService>, TService
        {
            var sp = services.BuildServiceProvider();

            services.AddTransient<TService>(x =>
            {
                var uow = sp.GetService<IUnitOfWork>();
                var realService = (TService) Activator.CreateInstance(typeof(TImplementation), uow);
                var logger = sp.GetService<ILogger<TImplementation>>();
                var proxy = (TLogProxy) Activator.CreateInstance(typeof(TLogProxy), realService, logger);
                return proxy;
            });
        }
    }
}