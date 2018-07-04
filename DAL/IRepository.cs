using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ras.DAL
{
    public interface IRepository<T>
    {
       IQueryable<T> All { get; }

        T Create(T item);

        T Read(params object[] key);

        T Update(T item);

        void Delete(T item);

        void Delete(params object[] key);
    }
}
