using System.Collections.Generic;

namespace Ras.Infastructure.Mapping
{
    public interface ITypeMapper<TFrom, TTo>
    {
        IEnumerable<TTo> Map(IEnumerable<TFrom> source);
        TTo Map(TFrom source);
    }
}
