using System;
using System.Collections.Generic;
using System.Text;
using Ras.BLL.DTO;
using Ras.DAL;
using Ras.DAL.Entity;
using System.Linq;
using Ras.BLL.Exceptions;
using System.Linq.Expressions;
using System.Reflection;

namespace Ras.BLL.Implementation
{
    public class GroupService : Service, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public void Create(GroupDTO group)
        {
                    unitOfWork.GroupsRepository.Create(new Group
                    {
                        Id = group.Id,
                        Name = group.Name,
                        CrmGroup = group.CrmGroup,
                        StartDate = group.StartDate,
                        EndDate = group.EndDate,
                        CityId = group.CityId,
                        DirectionId = group.DirectionId,
                        TechnologyId = group.TechnologyId,
                        StageId = group.StageId
                    });
                    unitOfWork.GroupsInfoRepsitory.Create(new GroupInfo
                    {
                        GroupName = group.Name,
                        StudentsPlannedToEnrollment = group.AmountStudentForEnrollment,
                        StudentsPlannedToGraduate = group.AmountStudentForGraduate,
                        AcademyId = group.Id
                    });
                    unitOfWork.SaveChanges();
        }

        public IEnumerable<GroupDTO> GetAll(string property, int skip, int count)
        {
            var groups = unitOfWork.GroupsRepository.All;
            var groupsList = OrderBy(groups, property).Skip(skip).Take(count).ToList();
            var groupsDto = new List<GroupDTO>();
            for (int i=0; i<groupsList.Count; i++)
            {
                groupsDto.Add(new GroupDTO(groupsList[i]));
            }
            return groupsDto;
        }

        public IEnumerable<GroupDTO> GetAll
            (
            string property,
            int skip, 
            int count,
            string name = "",
            DateTime? startdate = null,
            DateTime? enddate = null,
            int? cityid = null,
            int? directionid = null,
            int? technologyid = null,
            int? stageid = null)
        {
            var filter = unitOfWork.GroupsRepository.All;
            if (name != "")
            {
                filter = filter.Where(g => g.Name == name);
            }
            if (startdate != null)
            {
                filter = filter.Where(g => g.StartDate >= startdate);
            }
            if (enddate != null)
            {
                filter = filter.Where(g => g.EndDate <= enddate);
            }
            if (cityid != null)
            {
                filter = filter.Where(g => g.CityId == cityid);
            }
            if (directionid != null)
            {
                filter = filter.Where(g => g.DirectionId == directionid);
            }
            if (technologyid != null)
            {
                filter = filter.Where(g => g.TechnologyId == technologyid);
            }
            if (stageid != null)
            {
                filter = filter.Where(g => g.StageId == stageid);
            }
            var resultListOfGroup = new List<GroupDTO>();
            var tempList = OrderBy(filter, property).Skip(skip).Take(count).ToList();
            for (int i = 0; i < tempList.Count; i++)
            {
                resultListOfGroup.Add(new GroupDTO(tempList[i]));
            }
            return resultListOfGroup;
        }

        public GroupDTO GetById(int id)
        {
            var group = unitOfWork.GroupsRepository.Read(id);
            if (group==null)
            {
                throw new GroupNotFoundException();
            }
            else
            {
                var groupDto = new GroupDTO(group);
                groupDto.City = GetCity(groupDto.CityId);
                groupDto.AmountStudentForGraduate = GetCountStudentForGraduate(groupDto.Id);
                groupDto.AmountStudentForEnrollment = GetCountStudentForEnrollment(groupDto.Id);
                groupDto.AmountStudenActual = group.Students.Count;
                return groupDto;
            }
        }  

        public IEnumerable<StudentDTO> GetStudentsByGroupId(int groupId)
        {
            List<StudentDTO> studentDTOs = new List<StudentDTO>();
            try
            {
                var students = unitOfWork.StudentsRepository.All.Where(g => g.GroupId == groupId).ToList();
                for (int i = 0; i < students.Count; i++)
                {
                    studentDTOs.Add(new StudentDTO(students[i]));
                }
                return studentDTOs;
            }
            catch (Exception)
            {
                throw new GroupNotFoundException();
            }
        }

        public void Update(GroupDTO group)
        {
                unitOfWork.GroupsRepository.Update(new Group
                {
                    Id = group.Id,
                    Name = group.Name,
                    CrmGroup = group.CrmGroup,
                    StartDate = group.StartDate,
                    EndDate = group.EndDate,
                    CityId=group.CityId,
                    DirectionId = group.DirectionId,
                    TechnologyId = group.TechnologyId,
                    StageId = group.StageId
                });
                unitOfWork.SaveChanges();
        } //TODO: Information about count students



        private string GetCity(int Id)
        {
            var city = unitOfWork.LanguageTranslationsRepository.All.Where(c => c.Tag == "city");
            city = city.Where(c => c.Local == "en");
            city = city.Where(c => c.ItemId == Id); 
            return city.FirstOrDefault().Trasnlation;
        }

        private int GetCountStudentForGraduate(int groupId)
        {
            return unitOfWork.GroupsInfoRepsitory.All.Where(i => i.AcademyId == groupId).FirstOrDefault().StudentsPlannedToGraduate;
        }

        private int GetCountStudentForEnrollment(int groupId)
        {
            return unitOfWork.GroupsInfoRepsitory.All.Where(i => i.AcademyId == groupId).FirstOrDefault().StudentsPlannedToEnrollment;
        }

        public static IOrderedQueryable<T> OrderBy<T>(
            IQueryable<T> source,
            string property)
        {
            return ApplyOrder<T>(source, property, "OrderBy");
        }

        static IOrderedQueryable<T> ApplyOrder<T>(
            IQueryable<T> source,
            string property,
            string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }
    }
}
