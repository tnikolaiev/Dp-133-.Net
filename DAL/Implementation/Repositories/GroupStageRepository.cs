using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class GroupStageRepository : RasRepository<GroupStage>
    {
        public GroupStageRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<GroupStage> All => db.AcademyStages.AsNoTracking();

        public override GroupStage Create(GroupStage item)
        {
            return db.AcademyStages.Add(item).Entity;
        }

        public override GroupStage Read(params object[] key)
        {
            return db.AcademyStages.Find(key);
        }

        public override GroupStage Update(GroupStage item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(GroupStage item)
        {
            db.AcademyStages.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            var item = Read(key);
            if (item != null)
            {
                db.AcademyStages.Remove(item);
            }
        }
    }
}