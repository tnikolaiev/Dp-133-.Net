using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class GroupPaymentStatusRepository : RasRepository<GroupPaymentStatus>
    {
        public GroupPaymentStatusRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<GroupPaymentStatus> All => db.GroupPaymentStatus.AsNoTracking();

        public override GroupPaymentStatus Create(GroupPaymentStatus item)
        {
            return db.GroupPaymentStatus.Add(item).Entity;
        }

        public override GroupPaymentStatus Read(params object[] key)
        {
            return db.GroupPaymentStatus.Find(key);
        }

        public override GroupPaymentStatus Update(GroupPaymentStatus item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(GroupPaymentStatus item)
        {
            db.GroupPaymentStatus.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            var item = Read(key);
            if (item != null)
            {
                db.GroupPaymentStatus.Remove(item);
            }
        }
    }
}