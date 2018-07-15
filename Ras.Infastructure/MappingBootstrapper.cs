using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Ras.Infastructure.Mapping;
using Ras.Infastructure.Mapping.Implementation;

namespace Ras.Infastructure
{
    public static class MappingBootstrapper
    {
        public static void RegisterMapper<TFrom, TTo>(IServiceCollection services)
        {
            services.AddSingleton<ITypeMapper<TFrom, TTo>, AutoMapperBase<TFrom, TTo>>();
        }
    }
}
