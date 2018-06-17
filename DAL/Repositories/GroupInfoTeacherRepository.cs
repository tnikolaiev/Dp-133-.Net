﻿using System.Linq;
using Ras.DAL.EF;
using Ras.DAL.Entity;
using Ras.DAL.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Ras.DAL.Repositories
{
    public class GroupInfoTeacherRepository : RasRepository<GroupInfoTeacher>
    {
        public GroupInfoTeacherRepository(RasContext rasContext) : base(rasContext)
        {
        }

        public override IQueryable<GroupInfoTeacher> All => db.GroupInfoTeachers;

        public override GroupInfoTeacher Create(GroupInfoTeacher item)
        {
            return db.GroupInfoTeachers.Add(item).Entity;
        }

        public override GroupInfoTeacher Read(params object[] key)
        {
            return db.GroupInfoTeachers.Find(key);
        }

        public override GroupInfoTeacher Upate(GroupInfoTeacher item)
        {
            db.Entry(item).State = EntityState.Modified;
            return item;
        }

        public override void Delete(GroupInfoTeacher item)
        {
            db.GroupInfoTeachers.Remove(item);
        }

        public override void Delete(params object[] key)
        {
            GroupInfoTeacher item = Read(key);
            if (item != null)
            {
                db.GroupInfoTeachers.Remove(item);
            }
        }
    }
}
