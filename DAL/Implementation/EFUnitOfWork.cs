using System;
using Ras.DAL.EF;
using Ras.DAL.Entity;
using Ras.DAL.Implementation.Repositories;

namespace Ras.DAL.Implementation
{
    /// <summary>
    ///     Contains repositories. Each repository will be created on first access.
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly RasContext db;

        private CharacteristicRepository characteristicRepository;
        private DirectionRepository directionRepository;
        private EmployeeRepository employeeRepository;
        private EnglishLevelRepository englishLevelRepository;
        private FeedbackRepository feedbackRepository;
        private GroupInfoRepository groupInfoRepository;
        private GroupInfoTeacherRepository groupInfoTeacherRepository;
        private GroupInfoTestRepository groupInfoTestRepository;
        private GroupPaymentStatusRepository groupPaymentStatusRepository;
        private GroupRepository groupRepository;
        private GroupStageRepository groupStageRepository;
        private HistoryRepository historyRepository;
        private LanguageTranslationsRepository languageTranslationsRepository;
        private MarkRepository markRepository;
        private PersonalStatusRepository personalStatusRepository;
        private ProfileInfoRepository profileInfoRepository;
        private StudentRepository studentRepository;
        private StudentStatusRepository studentStatusRepository;
        private TeacherTypeRepository teacherTypeRepository;
        private TechnologyRepository technologyRepository;
        private UserRepository userRepository;

        private bool disposed;

        public EFUnitOfWork(string connectionString)
        {
            db = new RasContext(connectionString);
        }

        public IRepository<Group> GroupsRepository
        {
            get
            {
                if (groupRepository == null)
                {
                    groupRepository = new GroupRepository(db);
                }

                return groupRepository;
            }
        }

        public IRepository<GroupPaymentStatus> GroupPaymentStatusesRepository
        {
            get
            {
                if (groupPaymentStatusRepository == null)
                {
                    groupPaymentStatusRepository = new GroupPaymentStatusRepository(db);
                }

                return groupPaymentStatusRepository;
            }
        }

        public IRepository<ProfileInfo> ProfileInfosRepository
        {
            get
            {
                if (profileInfoRepository == null)
                {
                    profileInfoRepository = new ProfileInfoRepository(db);
                }

                return profileInfoRepository;
            }
        }

        public IRepository<GroupInfo> GroupsInfoRepsitory
        {
            get
            {
                if (groupInfoRepository == null)
                {
                    groupInfoRepository = new GroupInfoRepository(db);
                }

                return groupInfoRepository;
            }
        }

        public IRepository<GroupInfoTeacher> GroupInfoTeachersRepsitory
        {
            get
            {
                if (groupInfoTeacherRepository == null)
                {
                    groupInfoTeacherRepository = new GroupInfoTeacherRepository(db);
                }

                return groupInfoTeacherRepository;
            }
        }

        public IRepository<TeacherType> TeacherTypesRepsitory
        {
            get
            {
                if (teacherTypeRepository == null)
                {
                    teacherTypeRepository = new TeacherTypeRepository(db);
                }

                return teacherTypeRepository;
            }
        }

        public IRepository<Mark> MarksRepository
        {
            get
            {
                if (markRepository == null)
                {
                    markRepository = new MarkRepository(db);
                }

                return markRepository;
            }
        }

        public IRepository<Characteristic> CharacteristicsRepository
        {
            get
            {
                if (characteristicRepository == null)
                {
                    characteristicRepository = new CharacteristicRepository(db);
                }

                return characteristicRepository;
            }
        }

        public IRepository<Feedback> FeedbacksRepository
        {
            get
            {
                if (feedbackRepository == null)
                {
                    feedbackRepository = new FeedbackRepository(db);
                }

                return feedbackRepository;
            }
        }

        public IRepository<GroupStage> GroupStagesRepository
        {
            get
            {
                if (groupStageRepository == null)
                {
                    groupStageRepository = new GroupStageRepository(db);
                }

                return groupStageRepository;
            }
        }

        public IRepository<GroupInfoTest> GroupInfoTestsRepository
        {
            get
            {
                if (groupInfoTestRepository == null)
                {
                    groupInfoTestRepository = new GroupInfoTestRepository(db);
                }

                return groupInfoTestRepository;
            }
        }

        public IRepository<Student> StudentsRepository
        {
            get
            {
                if (studentRepository == null)
                {
                    studentRepository = new StudentRepository(db);
                }

                return studentRepository;
            }
        }

        public IRepository<StudentStatus> StudentStatusesRepository
        {
            get
            {
                if (studentStatusRepository == null)
                {
                    studentStatusRepository = new StudentStatusRepository(db);
                }

                return studentStatusRepository;
            }
        }

        public IRepository<PersonalStatus> PersonalStatusesRepository
        {
            get
            {
                if (personalStatusRepository == null)
                {
                    personalStatusRepository = new PersonalStatusRepository(db);
                }

                return personalStatusRepository;
            }
        }

        public IRepository<EnglishLevel> EnglishLevelsRepository
        {
            get
            {
                if (englishLevelRepository == null)
                {
                    englishLevelRepository = new EnglishLevelRepository(db);
                }

                return englishLevelRepository;
            }
        }

        public IRepository<Employee> EmployeesRepository
        {
            get
            {
                if (employeeRepository == null)
                {
                    employeeRepository = new EmployeeRepository(db);
                }

                return employeeRepository;
            }
        }

        public IRepository<User> UsersRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(db);
                }

                return userRepository;
            }
        }

        public IRepository<LanguageTranslations> LanguageTranslationsRepository
        {
            get
            {
                if (languageTranslationsRepository == null)
                {
                    languageTranslationsRepository = new LanguageTranslationsRepository(db);
                }

                return languageTranslationsRepository;
            }
        }

        public IRepository<Direction> DirectionsRepository
        {
            get
            {
                if (directionRepository == null)
                {
                    directionRepository = new DirectionRepository(db);
                }

                return directionRepository;
            }
        }

        public IRepository<Technology> TechnologiesRepository
        {
            get
            {
                if (technologyRepository == null)
                {
                    technologyRepository = new TechnologyRepository(db);
                }

                return technologyRepository;
            }
        }

        public IRepository<History> HistoryRepository
        {
            get
            {
                if (historyRepository == null)
                {
                    historyRepository = new HistoryRepository(db);
                }

                return historyRepository;
            }
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                disposed = true;
            }
        }
    }
}