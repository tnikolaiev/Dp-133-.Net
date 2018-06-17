using System.Linq;
using Ras.DAL.EF;
using Ras.DAL.Entity;
using Ras.DAL.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Ras.DAL.Repositories
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

        public override ProfileInfo Upate(ProfileInfo item)
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
            ProfileInfo item = Read(key);
            if (item != null)
            {
                db.ProfileInfo.Remove(item);
            }
        }
    }
}
