using System.Linq;
using Ras.DAL.EF;
using Ras.DAL.Entity;
using Ras.DAL.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Ras.DAL.Repositories
{
    public class TeacherTypeRepository : RasRepository<TeacherType>
    {
        public TeacherTypeRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<TeacherType> All => db.TeacherTypes;

        public override TeacherType Create(TeacherType item)
        {
            return db.TeacherTypes.Add(item).Entity;
        }

        public override TeacherType Read(params object[] key)
        {
            return db.TeacherTypes.Find(key);
        }

        public override TeacherType Upate(TeacherType item)
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
