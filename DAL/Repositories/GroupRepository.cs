﻿using System.Linq;
using Ras.DAL.EF;
using Ras.DAL.Entity;
using Ras.DAL.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Ras.DAL.Repositories
{
    public class GroupRepository : RasRepository<Group>
    {
        public GroupRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<Group> All => db.Groups;

        public override Group Create(Group item)
        {
            return db.Groups.Add(item).Entity;
        }

        public override void Delete(Group item)
        {
            db.Groups.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            Group item = Read(key);
            if (item != null)
            {
                db.Groups.Remove(item);
            }
        }

        public override Group Read(params object[] key)
        {
            return db.Groups.Find(key);
        }

        public override Group Upate(Group item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }
    }
}
