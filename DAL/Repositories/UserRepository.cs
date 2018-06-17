using System.Linq;
using Ras.DAL.EF;
using Ras.DAL.Entity;
using Ras.DAL.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Ras.DAL.Repositories
{
    public class UserRepository : RasRepository<User>
    {
        public UserRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<User> All => db.Users;

        public override User Create(User item)
        {
            return db.Users.Add(item).Entity;
        }

        public override User Read(params object[] key)
        {
            return db.Users.Find(key);
        }

        public override User Upate(User item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(User item)
        {
            db.Users.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            User item = Read(key);
            if (item != null)
            {
                db.Users.Remove(item);
            }
        }
    }
}
