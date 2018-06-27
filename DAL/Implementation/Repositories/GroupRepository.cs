using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class GroupRepository : RasRepository<Group>
    {
        public GroupRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<Group> All => db.Groups
                                                   .Include(g => g.City)
                                                   .Include(g => g.Direction)
                                                   .Include(g => g.Stage)
                                                   .Include(g => g.Technology)
                                                   .AsNoTracking();

        public override Group Create(Group item)
        {
            return db.Groups.Add(item).Entity;
        }

        public override void Delete(Group item)
        {
            db.Groups.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            Group item = Read(key);
            if (item != null)
            {
                db.Groups.Remove(item);
            }
        }

        public override Group Read(params object[] key)
        {
            return db.Groups
                     .Include(g => g.City)
                     .Include(g => g.Direction)
                     .Include(g => g.Stage)
                     .Include(g => g.Technology)
                     .FirstOrDefault(k => k.Id == (int)key[0]);
        }

        public override Group Update(Group item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}
