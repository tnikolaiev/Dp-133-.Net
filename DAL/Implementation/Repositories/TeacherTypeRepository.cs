using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class TeacherTypeRepository : RasRepository<TeacherType>
    {
        public TeacherTypeRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<TeacherType> All => db.TeacherTypes.AsNoTracking();

        public override TeacherType Create(TeacherType item)
        {
            return db.TeacherTypes.Add(item).Entity;
        }

        public override TeacherType Read(params object[] key)
        {
            return db.TeacherTypes.Find(key);
        }

        public override TeacherType Update(TeacherType item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(TeacherType item)
        {
            db.TeacherTypes.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            TeacherType item = Read(key);
            if (item != null)
            {
                db.TeacherTypes.Remove(item);
            }
        }
    }
}
