using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class HistoryRepository : RasRepository<History>
    {
        public HistoryRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<History> All => db.History.AsNoTracking();

        public override History Create(History item)
        {
            return db.History.Add(item).Entity;
        }

        public override History Read(params object[] key)
        {
            return db.History.Find(key);
        }

        public override History Upate(History item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(History item)
        {
            db.History.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            History item = Read(key);
            if (item != null)
            {
                db.History.Remove(item);
            }
        }
    }
}
