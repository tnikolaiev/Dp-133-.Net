using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class ProfileInfoRepository : RasRepository<ProfileInfo>
    {
        public ProfileInfoRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<ProfileInfo> All => db.ProfileInfo;

        public override ProfileInfo Create(ProfileInfo item)
        {
            return db.ProfileInfo.Add(item).Entity;
        }

        public override ProfileInfo Read(params object[] key)
        {
            return db.ProfileInfo.Find(key);
        }

        public override ProfileInfo Update(ProfileInfo item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(ProfileInfo item)
        {
            db.ProfileInfo.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            var item = Read(key);
            if (item != null)
            {
                db.ProfileInfo.Remove(item);
            }
        }
    }
}