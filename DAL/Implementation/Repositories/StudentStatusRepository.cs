using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class StudentStatusRepository : RasRepository<StudentStatus>
    {
        public StudentStatusRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<StudentStatus> All => db.StudentStatuses.AsNoTracking();

        public override StudentStatus Create(StudentStatus item)
        {
            return db.StudentStatuses.Add(item).Entity;
        }

        public override StudentStatus Read(params object[] key)
        {
            return db.StudentStatuses.Find(key);
        }

        public override StudentStatus Update(StudentStatus item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(StudentStatus item)
        {
            db.StudentStatuses.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            StudentStatus item = Read(key);
            if (item != null)
            {
                db.StudentStatuses.Remove(item);
            }
        }
    }
}
