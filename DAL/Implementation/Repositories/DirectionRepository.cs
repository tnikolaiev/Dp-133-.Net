using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class DirectionRepository : RasRepository<Direction>
    {
        public DirectionRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<Direction> All => db.Directions.AsNoTracking();

        public override Direction Create(Direction item)
        {
            return db.Directions.Add(item).Entity;
        }

        public override void Delete(Direction item)
        {
            db.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            Direction item = Read(key);
            if (item != null)
            {
                db.Directions.Remove(item);
            }
        }

        public override Direction Read(params object[] key)
        {
            return db.Directions.Find(key);
        }

        public override Direction Upate(Direction item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}
