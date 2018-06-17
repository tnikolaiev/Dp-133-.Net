using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class EnglishLevelRepository : RasRepository<EnglishLevel>
    {
        public EnglishLevelRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<EnglishLevel> All => db.EnglishLevel;

        public override EnglishLevel Create(EnglishLevel item)
        {
            return db.EnglishLevel.Add(item).Entity;
        }

        public override void Delete(EnglishLevel item)
        {
            db.EnglishLevel.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            EnglishLevel item = Read(key);
            if (item != null)
            {
                db.EnglishLevel.Remove(item);
            }
        }

        public override EnglishLevel Read(params object[] key)
        {
            return db.EnglishLevel.Find(key);
        }

        public override EnglishLevel Upate(EnglishLevel item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}
