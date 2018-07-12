using System.Collections.Generic;
using AutoMapper;
using Ras.Infastructure.Mapping;

namespace Ras.Infastructure.Mapping.Implementation
{
    internal class AutoMapperBase<TFrom, TTo> : ITypeMapper<TFrom, TTo>
    {
        private readonly static IMapper _mapper = new MapperConfiguration(cfg => cfg.CreateMap<TFrom, TTo>()).CreateMapper();

        protected IMapper Mapper => _mapper;

        public IEnumerable<TTo> Map(IEnumerable<TFrom> source)
        {
            return _mapper.Map<IEnumerable<TFrom>, IEnumerable<TTo>>(source);
        }

        public TTo Map(TFrom source)
        {
            return _mapper.Map<TFrom, TTo>(source);
        }
    }
}
