using System.Linq;
using Ras.DAL.EF;
using Ras.DAL.Entity;
using Ras.DAL.Implementation;
using Microsoft.EntityFrameworkCore;
namespace Ras.DAL.Repositories
{
    public class GroupInfoTestRepository : RasRepository<GroupInfoTest>
    {
        public GroupInfoTestRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<GroupInfoTest> All => db.GroupInfoTests;

        public override GroupInfoTest Create(GroupInfoTest item)
        {
            return db.GroupInfoTests.Add(item).Entity;
        }

        public override GroupInfoTest Read(params object[] key)
        {
            return db.GroupInfoTests.Find(key);
        }

        public override GroupInfoTest Upate(GroupInfoTest item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(GroupInfoTest item)
        {
            db.GroupInfoTests.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            GroupInfoTest item = Read(key);
            if (item != null)
            {
                db.GroupInfoTests.Remove(item);
            }
        }
    }
}
