using System.Linq;
using Ras.DAL.EF;
using Ras.DAL.Entity;
using Ras.DAL.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Ras.DAL.Repositories
{
    public class TechnologyRepository : RasRepository<Technology>
    {
        public TechnologyRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<Technology> All => db.Technologies;

        public override Technology Create(Technology item)
        {
            return db.Technologies.Add(item).Entity;
        }

        public override Technology Read(params object[] key)
        {
            return db.Technologies.Find(key);
        }

        public override Technology Upate(Technology item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(Technology item)
        {
            db.Technologies.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            Technology item = Read(key);
            if (item != null)
            {
                db.Technologies.Remove(item);
            }
        }
    }
}
