using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ras.BLL.DTO;
using Ras.BLL.Exceptions;
using Ras.DAL;
using Ras.DAL.Entity;

namespace Ras.BLL.Implementation
{
    public class GroupService : Service, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

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

        public IEnumerable<GroupDTO> GetAll(string orderby, int skip, int count)
        {
            var groups = unitOfWork.GroupsRepository.All;
            var groupsList = OrderBy(groups, orderby).Skip(skip).Take(count).ToList();
            var groupsDto = new List<GroupDTO>();
            for (int i = 0; i < groupsList.Count; i++)
            {
                groupsDto.Add(new GroupDTO(groupsList[i]));
                groupsDto[i].Name = GetNameGroup(groupsDto[i].Id);
                groupsDto[i].AmountStudentForGraduate = GetCountStudentForGraduate(groupsDto[i].Id);
                groupsDto[i].AmountStudentForEnrollment = GetCountStudentForEnrollment(groupsDto[i].Id);
                groupsDto[i].AmountStudenActual = groupsList[i].Students.Count;
            }

            return groupsDto;
        }

        public IEnumerable<GroupDTO> GetAll
        (
            string orderby,
            int skip,
            int count,
            string name = "",
            DateTime? startdate = null,
            DateTime? enddate = null,
            int? cityid = null,
            int? directionid = null,
            int? technologyid = null,
            int? stageid = null
        )
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
            var tempList = OrderBy(filter, orderby).Skip(skip).Take(count).ToList();
            for (int i = 0; i < tempList.Count; i++)
            {
                resultListOfGroup.Add(new GroupDTO(tempList[i]));
                resultListOfGroup[i].Name = GetNameGroup(tempList[i].Id);
                resultListOfGroup[i].AmountStudentForGraduate = GetCountStudentForGraduate(tempList[i].Id);
                resultListOfGroup[i].AmountStudentForEnrollment = GetCountStudentForEnrollment(tempList[i].Id);
                resultListOfGroup[i].AmountStudenActual = tempList[i].Students.Count;
            }

            return resultListOfGroup;
        }

        public GroupDTO GetById(int id)
        {
            var group = unitOfWork.GroupsRepository.Read(id);
            if (group == null)
            {
                throw new GroupNotFoundException();
            }

            var groupDto = new GroupDTO(group);
            if (groupDto.CityId != null)
            {
                groupDto.City = GetCity((int) groupDto.CityId);
            }

            groupDto.Name = GetNameGroup(groupDto.Id);
            groupDto.AmountStudentForGraduate = GetCountStudentForGraduate(groupDto.Id);
            groupDto.AmountStudentForEnrollment = GetCountStudentForEnrollment(groupDto.Id);
            groupDto.AmountStudenActual = group.Students.Count;
            return groupDto;
        }

        public IEnumerable<StudentDTO> GetStudentsByGroupId(int groupId)
        {
            var studentDTOs = new List<StudentDTO>();
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
                CityId = group.CityId,
                DirectionId = group.DirectionId,
                TechnologyId = group.TechnologyId,
                StageId = group.StageId
            });
            var groupinfo = unitOfWork.GroupsInfoRepsitory.All.Where(i => i.AcademyId == group.Id).FirstOrDefault();
            groupinfo.StudentsPlannedToEnrollment = group.AmountStudentForEnrollment;
            groupinfo.StudentsPlannedToGraduate = group.AmountStudentForGraduate;
            unitOfWork.GroupsInfoRepsitory.Update(groupinfo);
            unitOfWork.HistoryRepository.Create(new History
            {
                AcademyId = group.Id,
                AcademyName = group.Name,
                NameForSite = group.NameForSite,
                Location = group.City,
                StartDate = group.StartDate,
                EndDate = group.EndDate,
                Stage = group.Stage,
                Direction = group.Direction,
                ModifyDate = DateTime.Now
            }); //TODO: Modified by
            unitOfWork.SaveChanges();
        }

        public IEnumerable<EmployeeDTO> GetAllEployee()
        {
            var employees = unitOfWork.EmployeesRepository.All.ToList();
            var employeesDTO = new List<EmployeeDTO>();
            for (int i = 0; i < employees.Count; i++)
            {
                employeesDTO.Add(new EmployeeDTO(employees[i], null));
            }
            return employeesDTO;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployeesForGroup(int GroupId)
        {
            var employees = unitOfWork.GroupInfoTeachersRepsitory.All.Where(i => i.AcademyId == GroupId).ToList();
            var employeesDTO = new List<EmployeeDTO>();

            for (int i=0; i<employees.Count; i++)
            {
                employeesDTO.Add(new EmployeeDTO(unitOfWork.EmployeesRepository.Read(employees[i].EmployeeId), employees[i]));
            }
            return employeesDTO;
        }

        public void AddEmployeeToGroup(int groupId, int employeeId, int involved, int typeId)
        {
            if (unitOfWork.GroupInfoTeachersRepsitory.All.Where(a => a.AcademyId == groupId)
                                                        .Where(e => e.EmployeeId == employeeId).FirstOrDefault() == null)
            {
                unitOfWork.GroupInfoTeachersRepsitory.Create(new GroupInfoTeacher { AcademyId = groupId, EmployeeId = employeeId, Involved = involved, TeacherTypeId = typeId });
            }
            else throw new ArgumentException("Employee with such Id exist in this group");
        }
        public void DeleteEmployeeFromGroup(int groupId, int employeeId)
        {
            int id = unitOfWork.GroupInfoTeachersRepsitory.All.Where(a => a. AcademyId == groupId)
                                                                .Where(e => e.EmployeeId == employeeId).FirstOrDefault().Id;
            unitOfWork.EmployeesRepository.Delete(id);
        }

        public void UpdateEmployeeInGroup(EmployeeDTO employee)
        {
            unitOfWork.GroupInfoTeachersRepsitory.Update(new GroupInfoTeacher
            {
                AcademyId = employee.GroupId,
                EmployeeId = employee.EmployeeId,
                TeacherTypeId = employee.TeacherTypeId,
                Involved = employee.Involved
            });
        }

        private string GetCity(int Id)
        {
            var city = unitOfWork.LanguageTranslationsRepository.All.Where(c => c.Tag == "city");
            city = city.Where(c => c.Local == "en");
            city = city.Where(c => c.ItemId == Id);
            return city.FirstOrDefault().Trasnlation;
        }

        private string GetNameGroup(int groupId)
        {
            var group = unitOfWork.GroupsInfoRepsitory.All.Where(i => i.AcademyId == groupId).FirstOrDefault();
            if (group != null)
                return group.GroupName;
            else return "";
        }

        private int GetCountStudentForGraduate(int groupId)
        {
            var group = unitOfWork.GroupsInfoRepsitory.All.Where(i => i.AcademyId == groupId).FirstOrDefault();
            if (group != null)
                return group.StudentsPlannedToGraduate;
            else return 0;
        }

        private int GetCountStudentForEnrollment(int groupId)
        {
            var group = unitOfWork.GroupsInfoRepsitory.All.Where(i => i.AcademyId == groupId).FirstOrDefault();
            if (group != null)
                return group.StudentsPlannedToEnrollment;
            else return 0;
        }

        public static IOrderedQueryable<T> OrderBy<T>
        (
            IQueryable<T> source,
            string property
        )
        {
            return ApplyOrder(source, property, "OrderBy");
        }

        private static IOrderedQueryable<T> ApplyOrder<T>
        (
            IQueryable<T> source,
            string property,
            string methodName
        )
        {
            var props = property.Split('.');
            var type = typeof(T);
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                var pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }

            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            var lambda = Expression.Lambda(delegateType, expr, arg);

            var result = typeof(Queryable).GetMethods().Single(
                                              method => method.Name == methodName
                                                        && method.IsGenericMethodDefinition
                                                        && method.GetGenericArguments().Length == 2
                                                        && method.GetParameters().Length == 2)
                                          .MakeGenericMethod(typeof(T), type)
                                          .Invoke(null, new object[] {source, lambda});
            return (IOrderedQueryable<T>) result;
        }
    }
}