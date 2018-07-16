using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class StudentRepository : RasRepository<Student>
    {
        public StudentRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<Student> All => db.Students;

        public override Student Create(Student item)
        {
            return db.Students.Add(item).Entity;
        }

        public override Student Read(params object[] key)
        {
            return db.Students.Find(key);
        }

        public override Student Update(Student item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(Student item)
        {
            db.Students.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            var item = Read(key);
            if (item != null)
            {
                db.Students.Remove(item);
            }
        }
    }
}