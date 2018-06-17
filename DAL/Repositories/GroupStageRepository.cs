﻿using System.Linq;
using Ras.DAL.EF;
using Ras.DAL.Entity;
using Ras.DAL.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Ras.DAL.Repositories
{
    public class GroupStageRepository : RasRepository<GroupStage>
    {
        public GroupStageRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<GroupStage> All => db.AcademyStages;

        public override GroupStage Create(GroupStage item)
        {
            return db.AcademyStages.Add(item).Entity;
        }

        public override GroupStage Read(params object[] key)
        {
            return db.AcademyStages.Find(key);
        }

        public override GroupStage Upate(GroupStage item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(GroupStage item)
        {
            db.AcademyStages.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            GroupStage item = Read(key);
            if (item != null)
            {
                db.AcademyStages.Remove(item);
            }
        }
    }
}
