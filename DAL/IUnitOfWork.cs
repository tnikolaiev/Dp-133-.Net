using System;
using Ras.DAL.Entity;

namespace Ras.DAL
{
    /// <summary>
    ///     Container for repositories.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Group> GroupsRepository { get; }

        IRepository<GroupPaymentStatus> GroupPaymentStatusesRepository { get; }

        IRepository<ProfileInfo> ProfileInfosRepository { get; }

        IRepository<GroupInfo> GroupsInfoRepsitory { get; }

        IRepository<GroupInfoTeacher> GroupInfoTeachersRepsitory { get; }

        IRepository<TeacherType> TeacherTypesRepsitory { get; }

        IRepository<Mark> MarksRepository { get; }

        IRepository<Characteristic> CharacteristicsRepository { get; }

        IRepository<Feedback> FeedbacksRepository { get; }

        IRepository<GroupStage> GroupStagesRepository { get; }

        IRepository<GroupInfoTest> GroupInfoTestsRepository { get; }

        IRepository<Student> StudentsRepository { get; }

        IRepository<StudentStatus> StudentStatusesRepository { get; }

        IRepository<PersonalStatus> PersonalStatusesRepository { get; }

        IRepository<EnglishLevel> EnglishLevelsRepository { get; }

        IRepository<Employee> EmployeesRepository { get; }

        IRepository<User> UsersRepository { get; }

        IRepository<LanguageTranslations> LanguageTranslationsRepository { get; }

        IRepository<Direction> DirectionsRepository { get; }

        IRepository<Technology> TechnologiesRepository { get; }

        IRepository<History> HistoryRepository { get; }

        void SaveChanges();
    }
}