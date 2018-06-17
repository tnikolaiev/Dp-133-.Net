using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class FeedbackRepository : RasRepository<Feedback>
    {
        public FeedbackRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<Feedback> All => db.Feedback;

        public override Feedback Create(Feedback item)
        {
            return db.Feedback.Add(item).Entity;
        }

        public override void Delete(Feedback item)
        {
            db.Feedback.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            Feedback item = Read(key);
            if (item != null)
            {
                db.Feedback.Remove(item);
            }
        }

        public override Feedback Read(params object[] key)
        {
            return db.Feedback.Find(key);
        }

        public override Feedback Upate(Feedback item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}
