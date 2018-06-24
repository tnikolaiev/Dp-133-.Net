using System.Linq;
using Ras.DAL.EF;

namespace Ras.DAL.Implementation
{
    public abstract class RasRepository<T> : IRepository<T>
    {
        protected RasContext db;

        public RasRepository(RasContext db)
        {
            this.db = db;
        }

        public abstract IQueryable<T> All { get; }
        public abstract T Create(T item);
        public abstract T Read(params object[] key);
        public abstract T Update(T item);
        public abstract void Delete(T item);
        public abstract void Delete(params object[] key);
    }
}