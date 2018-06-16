using System;
using System.Collections.Generic;
using System.Text;
using Ras.DAL.Entity;

namespace Ras.DAL
{
    interface IUnitOfWork
    {
        IRepository<Group> GroupsRepository { get; }

        IRepository<Student> StudentsRepository { get; }

        IRepository<GroupInfo> GroupsInfoRepsitory { get; }

        IRepository<GroupStage> GroupStagesRepository { get; }

        IRepository<LanguageTranslations> LanguageTranslationsRepository { get; }

        IRepository<Direction> DirectionsRepository { get; }

        IRepository<Technology> TechnologiesRepository { get; }

        void SaveChanges();
    }
}
