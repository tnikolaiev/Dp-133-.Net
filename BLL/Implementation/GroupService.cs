using System;
using System.Collections.Generic;
using System.Text;
using Ras.BLL.DTO;
using Ras.DAL;
using Ras.DAL.Entity;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Ras.BLL.Implementation
{
    public class GroupService : Service, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public void Create(GroupDTO group)
        {
            if (group != null)
            {
                try
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
                catch (Exception)
                {
                    
                }
            }
            else
            {
                throw new ArgumentException("Error");
            }
        }

        public IEnumerable<GroupDTO> GetAll()
        {
            var groups = unitOfWork.GroupsRepository.All.ToList();
            var groupsDto = new List<GroupDTO>();
            for (int i=0; i<groups.Count; i++)
            {
                groupsDto.Add(new GroupDTO(groups[i]));
            }
            return groupsDto;
        }

        public IEnumerable<GroupDTO> GetAll
            (string name = "",
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
            var tempList = filter.ToList();
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
                throw new ArgumentException("Group with such id does not exist!");
            }
            else
            {
                var groupDto = new GroupDTO(group);
                groupDto.City = GetCity(groupDto.CityId);
                groupDto.AmountStudentForGraduate = getCountStudentForGraduate(groupDto.Id);
                groupDto.AmountStudentForEnrollment = getCountStudentForEnrollment(groupDto.Id);
                return groupDto;
            }
        } //TODO: Create class for exception 

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
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
        }

        public void Update(GroupDTO group)
        {
            if (group != null)
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
            }
        } //TODO: Information about count students



        private string GetCity(int Id)
        {
            var city = unitOfWork.LanguageTranslationsRepository.All.Where(c => c.Tag == "city");
            city = city.Where(c => c.Local == "en");
            city = city.Where(c => c.ItemId == Id); 
            return city.FirstOrDefault().Trasnlation;
        }

        private int getCountStudentForGraduate(int groupId)
        {
            return unitOfWork.GroupsInfoRepsitory.All.Where(i => i.AcademyId == groupId).FirstOrDefault().StudentsPlannedToGraduate;
        }

        private int getCountStudentForEnrollment(int groupId)
        {
            return unitOfWork.GroupsInfoRepsitory.All.Where(i => i.AcademyId == groupId).FirstOrDefault().StudentsPlannedToEnrollment;
        }


    }
}
