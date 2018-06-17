﻿using System.Linq;
using Ras.DAL.EF;
using Ras.DAL.Entity;
using Ras.DAL.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Ras.DAL.Repositories
{
    public class GroupPaymentStatusRepository : RasRepository<GroupPaymentStatus>
    {
        public GroupPaymentStatusRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<GroupPaymentStatus> All => db.GroupPaymentStatus;

        public override GroupPaymentStatus Create(GroupPaymentStatus item)
        {
            return db.GroupPaymentStatus.Add(item).Entity;
        }

        public override GroupPaymentStatus Read(params object[] key)
        {
            return db.GroupPaymentStatus.Find(key);
        }

        public override GroupPaymentStatus Upate(GroupPaymentStatus item)
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
            GroupPaymentStatus item = Read(key);
            if (item != null)
            {
                db.GroupPaymentStatus.Remove(item);
            }
        }
    }
}
