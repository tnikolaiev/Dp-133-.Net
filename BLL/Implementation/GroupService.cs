using System;
using System.Collections.Generic;
using System.Text;
using Ras.BLL.DTO;
using Ras.DAL;
using Ras.DAL.Entity;
using System.Linq;

namespace Ras.BLL.Implementation
{
    public class GroupService : Service, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
        public void Create(GroupDTO group)
        {
            unitOfWork.GroupsRepository.Create(new Group {
                Id = group.Id,
                Name = group.Name,
                CrmGroup = group.CrmGroup,
                StartDate = group.StartDate,
                EndDate = group.EndDate,
                //TODO: City
                DirectionId = group.DirectionId,
                TechnologyId = group.TechnologyId,
                StageId = group.StageId
            });
            unitOfWork.SaveChanges();
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

        public IEnumerable<GroupDTO> GetAll(string name, DateTime? startdate, DateTime? enddate, int? cityid, int? directionid, int? technologyid, int? stageid)
        {
            var filter = unitOfWork.GroupsRepository.All;
            if (name!="")
            {
                filter = filter.Where(g => g.Name == name);
            }
            if (startdate!=null)
            {
                filter = filter.Where(g => g.StartDate >= startdate);
            }
            if (enddate!=null)
            {
                filter = filter.Where(g => g.EndDate <= enddate);
            }
            if (cityid!=null)
            {
                filter = filter.Where(g => g.CityId == cityid);
            }
            if (directionid!=null)
            {
                filter = filter.Where(g => g.DirectionId == directionid);
            }
            if (technologyid!=null)
            {
                filter = filter.Where(g => g.TechnologyId == technologyid);
            }
            if (stageid!=null)
            {
                filter = filter.Where(g => g.StageId == stageid);
            }
            var resultListOfGroup = new List<GroupDTO>();
            var tempList = filter.ToList();
            for (int i=0; i<tempList.Count; i++)
            {
                resultListOfGroup.Add(new GroupDTO(tempList[i]));
            }
            return resultListOfGroup;
        }

        public GroupDTO GetById(int id)
        {
            return new GroupDTO(unitOfWork.GroupsRepository.Read(id));
        }

        public IEnumerable<StudentDTO> GetStudentsByGroupId(int groupId)
        {
            var students = unitOfWork.StudentsRepository.All.Where(g => g.GroupId == groupId).ToList();
            List<StudentDTO> studentDTOs = new List<StudentDTO>();
            for (int i=0; i<students.Count; i++)
            {
                studentDTOs.Add(new StudentDTO(students[i]));
            }
            return studentDTOs;            
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
                //TODO: City
                DirectionId = group.DirectionId,
                TechnologyId = group.TechnologyId,
                StageId = group.StageId
            });
            unitOfWork.SaveChanges();
        }
    }
}
