using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class LanguageTranslationsRepository : RasRepository<LanguageTranslations>
    {
        public LanguageTranslationsRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<LanguageTranslations> All => db.LanguageTranslations;

        public override LanguageTranslations Create(LanguageTranslations item)
        {
            return db.LanguageTranslations.Add(item).Entity;
        }

        public override LanguageTranslations Read(params object[] key)
        {
            return db.LanguageTranslations.Find(key);
        }

        public override LanguageTranslations Upate(LanguageTranslations item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(LanguageTranslations item)
        {
            db.LanguageTranslations.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            LanguageTranslations item = Read(key);
            if (item != null)
            {
                db.LanguageTranslations.Remove(item);
            }
        }
    }
}
