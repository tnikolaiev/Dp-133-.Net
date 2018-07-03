using System;
using Ras.BLL.DTO;
using Ras.DAL;
using Ras.DAL.Entity;
using Ras.BLL.Exeption;
using System.Linq;


namespace Ras.BLL.Implementation
{
    public enum TypeOfFeeadBack
    {
        teacher,
        expert
    }
    public class StudentService : Service, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public StudentDTO GetById(int id)
        {
            var dStudent = unitOfWork.StudentsRepository.Read(id);
            if (dStudent == null)
            {
                throw new StudentExeption();
            }
            return new StudentDTO(dStudent);
        }

        public StudentDTO CreateStudent(int userId, int groupId)
        {
            var dUser = unitOfWork.UsersRepository.Read(userId);
            var dStudent = new Student
            {
                User = dUser,
                GroupId = groupId,
            };

            var student = new StudentDTO(unitOfWork.StudentsRepository.Create(dStudent));

            unitOfWork.SaveChanges();
            return student;
        }

        public StudentDTO UpdateStudent(StudentDTO student)
        {
            Student dStudent = unitOfWork.StudentsRepository.Read(student.Id);
            StudentDTO newStudent = null;
            if (dStudent != null)
            {
                dStudent.EngGram = student.EnglishGrammar;
                dStudent.EnglishLevelId = unitOfWork.EnglishLevelsRepository.All.FirstOrDefault(x => x.Name == student.EnglishLevel).EnglishLevelId;
                dStudent.EntryScore = student.EntryScore;
                dStudent.ExpertScore = student.ExpertScore;
                dStudent.FinalBase = student.FinalBase;
                dStudent.IncomingTest = (int?)student.IncomingTest;
                dStudent.IntermTestBase = student.IntermTestBase;
                dStudent.IntermTestLang = student.IntermTestLang;
                dStudent.InterviewerComment = student.InterviewerComment;
                dStudent.InterviewerScore = student.InterviewerScore;
                dStudent.StudentStatusId =unitOfWork.StudentStatusesRepository.All.FirstOrDefault(x=>x.Name== student.StudentStatus).Id;
                dStudent.TeacherScore = student.TeacherScore;
                dStudent.Test1 = student.Tests[0];
                dStudent.Test2 = student.Tests[1];
                dStudent.Test3 = student.Tests[2];
                dStudent.Test4 = student.Tests[3];
                dStudent.Test5 = student.Tests[4];
                dStudent.Test6 = student.Tests[5];
                dStudent.Test7 = student.Tests[6];
                dStudent.Test8 = student.Tests[7];
                dStudent.Test9 = student.Tests[8];
                dStudent.Test10 = student.Tests[9];
                newStudent = new StudentDTO(unitOfWork.StudentsRepository.Upate(dStudent));
                unitOfWork.SaveChanges();
                return newStudent;
            }

            throw new StudentExeption();          
        }

        public FeedbackDTO UpdateFeedback(FeedbackDTO feedback)
        {
            Feedback dFeedBack = unitOfWork.FeedbacksRepository.Read(feedback.Id);
            FeedbackDTO newFeedBack = null;
            if (dFeedBack != null)
            {
                CopyMembers(feedback, dFeedBack);
                newFeedBack = new FeedbackDTO(unitOfWork.FeedbacksRepository.Upate(dFeedBack));
                unitOfWork.SaveChanges();
                return newFeedBack;
            }

            throw new FeedbackExeption();          
        }

        // feedback.ActiveCommunicatorTitle = "Learning ability"; feedback.ActiveCommunicatorCharacteristic = "Quick";
        public FeedbackDTO CreateFeedback(int studentId, TypeOfFeeadBack typeOfFeeadBack, FeedbackDTO feedback)
        {
            Student dStudent = unitOfWork.StudentsRepository.Read(studentId);
            dStudent = unitOfWork.StudentsRepository.All.FirstOrDefault() ;          
            if (dStudent == null) throw new StudentExeption();
            var creatingFeedback = new Feedback();
            CopyMembers(feedback, creatingFeedback);
            var newFeedBack = new FeedbackDTO(unitOfWork.FeedbacksRepository.Create(creatingFeedback));          
            switch (typeOfFeeadBack)
            {
                case TypeOfFeeadBack.expert:
                    {
                        dStudent.ExpertStudentFeedbackId = newFeedBack.Id;
                        break;
                    }
                case TypeOfFeeadBack.teacher:
                    {
                        dStudent.TeacherStudentFeedbackId = newFeedBack.Id;
                        break;
                    }
            }

            unitOfWork.StudentsRepository.Upate(dStudent);
            unitOfWork.SaveChanges();
            return newFeedBack;
        }
      
        public void Delete(int id)
        {
            unitOfWork.StudentsRepository.Delete(id);
            unitOfWork.SaveChanges();
        }

        private void CopyMembers(FeedbackDTO feedback,Feedback creatingFeedback)
        {
            int? activeCommunicatorId = unitOfWork.CharacteristicsRepository.All.FirstOrDefault(x => x.Name == feedback.ActiveCommunicatorTitle).CharacteristicId;
            creatingFeedback.ActiveCommunicatorId = unitOfWork.MarksRepository.All.FirstOrDefault(x => x.CharacteristicId == activeCommunicatorId && x.Name == feedback.ActiveCommunicatorCharacteristic).MarkId;

            int? gettingThingsDoneId = unitOfWork.CharacteristicsRepository.All.FirstOrDefault(x => x.Name == feedback.GettingThingsDoneTitle).CharacteristicId;
            creatingFeedback.GettingThingsDoneId = unitOfWork.MarksRepository.All.FirstOrDefault(x => x.CharacteristicId == gettingThingsDoneId && x.Name == feedback.GettingThingsDoneCharacteristic).MarkId;

            int? learningAbilityId = unitOfWork.CharacteristicsRepository.All.FirstOrDefault(x => x.Name == feedback.LearningAbilityTitle).CharacteristicId;
            creatingFeedback.LearningAbilityId = unitOfWork.MarksRepository.All.FirstOrDefault(x => x.CharacteristicId == learningAbilityId && x.Name == feedback.LearningAbilityCharacteristic).MarkId;

            int? passionalInitiativeId = unitOfWork.CharacteristicsRepository.All.FirstOrDefault(x => x.Name == feedback.PassionalInitiativeTitle).CharacteristicId;
            creatingFeedback.PassionalInitiativeId = unitOfWork.MarksRepository.All.FirstOrDefault(x => x.CharacteristicId == passionalInitiativeId && x.Name == feedback.PassionalInitiativeCharacteristic).MarkId;

            int? teamWorkId = unitOfWork.CharacteristicsRepository.All.FirstOrDefault(x => x.Name == feedback.TeamWorkTitle).CharacteristicId;
            creatingFeedback.TeamWorkId = unitOfWork.MarksRepository.All.FirstOrDefault(x => x.CharacteristicId == teamWorkId && x.Name == feedback.TeamWorkCharacteristic).MarkId;

            int? technicalCompetenceId = unitOfWork.CharacteristicsRepository.All.FirstOrDefault(x => x.Name == feedback.TechnicalCompetenceTitle).CharacteristicId;
            creatingFeedback.TechnicalCompetenceId = unitOfWork.MarksRepository.All.FirstOrDefault(x => x.CharacteristicId == technicalCompetenceId && x.Name == feedback.TechnicalCompetenceCharacteristic).MarkId;

            creatingFeedback.SummaryComment = feedback.SummaryComment;
        }
    }
}