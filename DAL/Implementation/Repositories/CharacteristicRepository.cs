using System.Linq;
using Microsoft.EntityFrameworkCore;
using Ras.DAL.EF;
using Ras.DAL.Entity;

namespace Ras.DAL.Implementation.Repositories
{
    public class CharacteristicRepository : RasRepository<Characteristic>
    {
        public CharacteristicRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<Characteristic> All => db.Characteristic;

        public override Characteristic Create(Characteristic item)
        {
            return db.Characteristic.Add(item).Entity;
        }

        public override void Delete(Characteristic item)
        {
            db.Characteristic.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            Characteristic item = Read(key);
            if (item != null)
            {
                db.Characteristic.Remove(item);
            }
        }

        public override Characteristic Read(params object[] key)
        {
            return db.Characteristic.Find(key);
        }

        public override Characteristic Upate(Characteristic item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}
