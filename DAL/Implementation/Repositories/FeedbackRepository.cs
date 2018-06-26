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

        public override IQueryable<Feedback> All => db.Feedback.AsNoTracking();

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
            db.Feedback.Include(x => x.ActiveCommunicator).ThenInclude(x=>x.Characteristic).FirstOrDefault(k=>k.FeedbackId==(int)key[0]);
            db.Feedback.Include(x => x.GettingThingsDone).ThenInclude(x => x.Characteristic).FirstOrDefault(k => k.FeedbackId == (int)key[0]);
            db.Feedback.Include(x => x.LearningAbility).ThenInclude(x => x.Characteristic).FirstOrDefault(k => k.FeedbackId == (int)key[0]);
            db.Feedback.Include(x => x.PassionalInitiative).ThenInclude(x => x.Characteristic).FirstOrDefault(k => k.FeedbackId == (int)key[0]);
            db.Feedback.Include(x => x.TeamWork).ThenInclude(x => x.Characteristic).FirstOrDefault(k => k.FeedbackId == (int)key[0]);
            db.Feedback.Include(x => x.TechnicalCompetence).ThenInclude(x => x.Characteristic).FirstOrDefault(k => k.FeedbackId == (int)key[0]);
            return db.Feedback.Find(key);
        }

        public override Feedback Update(Feedback item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}
