using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class MarkRepository : RasRepository<Mark>
    {
        public MarkRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<Mark> All => db.Mark.AsNoTracking();

        public override Mark Create(Mark item)
        {
            return db.Mark.Add(item).Entity;
        }

        public override Mark Read(params object[] key)
        {
            return db.Mark.Find(key);
        }

        public override Mark Update(Mark item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(Mark item)
        {
            db.Mark.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            Mark item = Read(key);
            if (item != null)
            {
                db.Mark.Remove(item);
            }
        }
    }
}
