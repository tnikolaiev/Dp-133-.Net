//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using Ras.DAL;
//using Ras.DAL.Implementation;
//using Ras.BLL;
//using Ras.BLL.Implementation;
//using Ras.BLL.Implementation.Proxies.Logging;
//using System.Reflection;

//namespace Ras.Infastructure
//{
//    public static class Binder
//    {
//        public static void BindServices(IServiceCollection services, string connectionString)
//        {
//            services.AddTransient<IUnitOfWork>
//                (s => new EFUnitOfWork(connectionString));

//            var sp = services.BuildServiceProvider();
//            var uow = sp.GetService<IUnitOfWork>();

//            services.AddTransient<IStudentService>(s =>
//            {
//                var ss = new StudentService(uow);
//                var logger = s.GetService<ILogger<StudentServiceLogProxy>>();

//                return new StudentServiceLogProxy(ss, logger);
//            });


//            BindService<IStudentService,>
//        }

//        private static void BindService<TService, TImplementation, TProxy1>(IServiceCollection services)
//            where TImplementation : Service, TService
//        where TProxy1 : 
//        {
//            var sp = services.BuildServiceProvider();
//            var uow = sp.GetService<IUnitOfWork>();

//            var ss = (TService) Activator.CreateInstance(typeof(TImplementation), uow);
//            var logger = sp.GetService<ILogger<TImplementation>>();

//            Activator.CreateInstance(typeof())

//            var logProxy = new StudentServiceLogProxy(ss, logger);



//        }
//    }
//}
