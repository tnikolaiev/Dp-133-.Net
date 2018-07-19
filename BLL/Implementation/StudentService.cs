﻿using System.Collections.Generic;
using System.Linq;
using Ras.BLL.DTO;
using Ras.BLL.Enums;
using Ras.BLL.Exeptions;
using Ras.DAL;
using Ras.DAL.Entity;

namespace Ras.BLL.Implementation
{
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
                throw new StudentNotFoundException();
            }

            return new StudentDTO(dStudent);
        }

        public StudentDTO CreateStudent(int userId, int groupId)
        {
            var dUser = unitOfWork.UsersRepository.Read(userId);
            var dStudent = new Student
            {
                User = dUser,
                GroupId = groupId
            };

            var student = new StudentDTO(unitOfWork.StudentsRepository.Create(dStudent));

            unitOfWork.SaveChanges();
            return student;
        }

        public StudentDTO UpdateStudent(StudentDTO student)
        {
            var dStudent = unitOfWork.StudentsRepository.Read(student.Id);
            StudentDTO newStudent = null;
            if (dStudent != null)
            {
                dStudent.EngGram = student.EnglishGrammar;
                dStudent.EnglishLevelId = unitOfWork.EnglishLevelsRepository.All.FirstOrDefault(x => x.Name == student.EnglishLevel)?.EnglishLevelId;
                dStudent.EntryScore = student.EntryScore;
                dStudent.ExpertScore = student.ExpertScore;
                dStudent.FinalBase = student.FinalBase;
                dStudent.IncomingTest = (int?) student.IncomingTest;
                dStudent.IntermTestBase = student.IntermTestBase;
                dStudent.IntermTestLang = student.IntermTestLang;
                dStudent.InterviewerComment = student.InterviewerComment;
                dStudent.InterviewerScore = student.InterviewerScore;
                dStudent.StudentStatusId = unitOfWork.StudentStatusesRepository.All.FirstOrDefault(x => x.Name == student.StudentStatus)?.Id;
                dStudent.TeacherScore = student.TeacherScore;
                dStudent.Test1 = student.Tests?[0];
                dStudent.Test2 = student.Tests?[1];
                dStudent.Test3 = student.Tests?[2];
                dStudent.Test4 = student.Tests?[3];
                dStudent.Test5 = student.Tests?[4];
                dStudent.Test6 = student.Tests?[5];
                dStudent.Test7 = student.Tests?[6];
                dStudent.Test8 = student.Tests?[7];
                dStudent.Test9 = student.Tests?[8];
                dStudent.Test10 = student.Tests?[9];
                newStudent = new StudentDTO(unitOfWork.StudentsRepository.Update(dStudent));
                unitOfWork.SaveChanges();
                return newStudent;
            }

            throw new StudentNotFoundException();
        }

        public FeedbackDTO UpdateFeedback(FeedbackDTO feedback)
        {
            var dFeedBack = unitOfWork.FeedbacksRepository.Read(feedback.Id);
            FeedbackDTO newFeedBack = null;
            if (dFeedBack != null)
            {
                CopyMembers(feedback, dFeedBack);
                newFeedBack = new FeedbackDTO(unitOfWork.FeedbacksRepository.Update(dFeedBack));
                unitOfWork.SaveChanges();
                return newFeedBack;
            }

            throw new FeedbackNotFoundExeption();
        }

        public FeedbackDTO CreateFeedback(int studentId, TypeOfFeedBack typeOfFeeadBack, FeedbackDTO feedback)
        {
            var dStudent = unitOfWork.StudentsRepository.Read(studentId);
            if (dStudent == null)
            {
                throw new StudentNotFoundException();
            }

            var creatingFeedback = new Feedback();
            CopyMembers(feedback, creatingFeedback);
            var newFeedBack = new FeedbackDTO(unitOfWork.FeedbacksRepository.Create(creatingFeedback));
            switch (typeOfFeeadBack)
            {
                case TypeOfFeedBack.expert:
                {
                    dStudent.ExpertStudentFeedbackId = newFeedBack.Id;
                    break;
                }
                case TypeOfFeedBack.teacher:
                {
                    dStudent.TeacherStudentFeedbackId = newFeedBack.Id;
                    break;
                }
            }

            unitOfWork.StudentsRepository.Update(dStudent);
            unitOfWork.SaveChanges();
            return newFeedBack;
        }

        public FeedbackDTO GetFeedback(int studentId, TypeOfFeedBack typeOfFeeadBack)
        {
            var dStudent = unitOfWork.StudentsRepository.Read(studentId);
            if (dStudent == null)
            {
                throw new StudentNotFoundException();
            }


            Feedback feedback = null;
            switch (typeOfFeeadBack)
            {
                case TypeOfFeedBack.expert:
                {
                    feedback = unitOfWork.FeedbacksRepository.Read(dStudent.ExpertStudentFeedback.FeedbackId);
                    break;
                }
                case TypeOfFeedBack.teacher:
                {
                    feedback = unitOfWork.FeedbacksRepository.Read(dStudent.TeacherStudentFeedback.FeedbackId);

                    break;
                }
            }

            if (feedback != null)
            {
                return new FeedbackDTO(feedback);
            }

            throw new FeedbackNotFoundExeption();
        }

        public void Delete(int id)
        {
            unitOfWork.StudentsRepository.Delete(id);
            unitOfWork.SaveChanges();
        }

        public IEnumerable<FeedbackDTO> GetFeedBacksInGroup(int groupId, TypeOfFeedBack typeOfFeeadBack)
        {
            IEnumerable<FeedbackDTO> feedbacks = null;
            switch (typeOfFeeadBack)
            {
                case TypeOfFeedBack.expert:
                {
                    feedbacks = unitOfWork.GroupsRepository.Read(groupId)?.Students.Select(x => new FeedbackDTO(x.ExpertStudentFeedback));
                    break;
                }
                case TypeOfFeedBack.teacher:
                {
                    feedbacks = unitOfWork.GroupsRepository.Read(groupId)?.Students.Select(x => new FeedbackDTO(x.TeacherStudentFeedback));
                    break;
                }
            }

            return feedbacks;
        }

        private void CopyMembers(FeedbackDTO feedback, Feedback creatingFeedback)
        {
            var activeCommunicatorId = unitOfWork.CharacteristicsRepository.All
                                                 .FirstOrDefault(x => x.Name == feedback.ActiveCommunicatorCharacteristic)?.CharacteristicId;
            creatingFeedback.ActiveCommunicatorId = unitOfWork.MarksRepository.All
                                                              .FirstOrDefault(
                                                                  x => x.CharacteristicId == activeCommunicatorId &&
                                                                       x.Name == feedback.ActiveCommunicatorTitle)?.MarkId;

            var gettingThingsDoneId = unitOfWork.CharacteristicsRepository.All.FirstOrDefault(x => x.Name == feedback.GettingThingsDoneCharacteristic)
                                                ?.CharacteristicId;
            creatingFeedback.GettingThingsDoneId = unitOfWork.MarksRepository.All
                                                             .FirstOrDefault(
                                                                 x => x.CharacteristicId == gettingThingsDoneId &&
                                                                      x.Name == feedback.GettingThingsDoneTitle)?.MarkId;

            var learningAbilityId = unitOfWork.CharacteristicsRepository.All.FirstOrDefault(x => x.Name == feedback.LearningAbilityCharacteristic)
                                              ?.CharacteristicId;
            creatingFeedback.LearningAbilityId = unitOfWork.MarksRepository.All
                                                           .FirstOrDefault(
                                                               x => x.CharacteristicId == learningAbilityId &&
                                                                    x.Name == feedback.LearningAbilityTitle)?.MarkId;

            var passionalInitiativeId = unitOfWork.CharacteristicsRepository.All
                                                  .FirstOrDefault(x => x.Name == feedback.PassionalInitiativeCharacteristic)?.CharacteristicId;
            creatingFeedback.PassionalInitiativeId = unitOfWork.MarksRepository.All
                                                               .FirstOrDefault(
                                                                   x => x.CharacteristicId == passionalInitiativeId &&
                                                                        x.Name == feedback.PassionalInitiativeTitle)?.MarkId;

            var teamWorkId = unitOfWork.CharacteristicsRepository.All.FirstOrDefault(x => x.Name == feedback.TeamWorkCharacteristic)
                                       ?.CharacteristicId;
            creatingFeedback.TeamWorkId = unitOfWork.MarksRepository.All
                                                    .FirstOrDefault(x => x.CharacteristicId == teamWorkId && x.Name == feedback.TeamWorkTitle)
                                                    ?.MarkId;

            var technicalCompetenceId = unitOfWork.CharacteristicsRepository.All
                                                  .FirstOrDefault(x => x.Name == feedback.TechnicalCompetenceCharacteristic)?.CharacteristicId;
            creatingFeedback.TechnicalCompetenceId = unitOfWork.MarksRepository.All
                                                               .FirstOrDefault(
                                                                   x => x.CharacteristicId == technicalCompetenceId &&
                                                                        x.Name == feedback.TechnicalCompetenceTitle)?.MarkId;

            creatingFeedback.SummaryComment = feedback.SummaryComment;
        }
    }
}