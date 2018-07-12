using Microsoft.Extensions.DependencyInjection;
using Ras.BLL.Implementation;

namespace Ras.BLL
{
    public class Bootstrapper
    {
        public static void Execute(IServiceCollection services)
        {
            services.AddTransient<IGroupHistoryService, GroupHistoryService>();
        }
    }
}
