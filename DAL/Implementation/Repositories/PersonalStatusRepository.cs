using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class PersonalStatusRepository : RasRepository<PersonalStatus>
    {
        public PersonalStatusRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<PersonalStatus> All => db.PersonalStatuses;

        public override PersonalStatus Create(PersonalStatus item)
        {
            return db.PersonalStatuses.Add(item).Entity;
        }

        public override PersonalStatus Read(params object[] key)
        {
            return db.PersonalStatuses.Find(key);
        }

        public override PersonalStatus Upate(PersonalStatus item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(PersonalStatus item)
        {
            db.PersonalStatuses.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            PersonalStatus item = Read(key);
            if (item != null)
            {
                db.PersonalStatuses.Remove(item);
            }
        }
    }
}
