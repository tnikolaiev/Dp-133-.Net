﻿using System.Linq;
using Ras.DAL.EF;
using Ras.DAL.Entity;
using Ras.DAL.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Ras.DAL.Repositories
{
    public class GroupInfoRepository : RasRepository<GroupInfo>
    {
        public GroupInfoRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<GroupInfo> All => db.GroupInfo;

        public override GroupInfo Create(GroupInfo item)
        {
            return db.GroupInfo.Add(item).Entity;
        }

        public override GroupInfo Read(params object[] key)
        {
            return db.GroupInfo.Find(key);
        }

        public override GroupInfo Upate(GroupInfo item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(GroupInfo item)
        {
            db.GroupInfo.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            GroupInfo item = Read(key);
            if (item != null)
            {
                db.GroupInfo.Remove(item);
            }
        }
    }
}
