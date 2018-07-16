using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ras.BLL;
using Ras.BLL.DTO;
using Ras.Infastructure.Mapping;
using Ras.Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class GroupsController : Controller
    {
        private readonly IGroupService groupService;
        private IMapper groupMapper;
        private ITypeMapper<StudentDTO, StudentViewModel> studentMapper;

        public GroupsController(IGroupService groupService, ITypeMapper<StudentDTO, StudentViewModel> studentMapper)
        {
            this.groupService = groupService;
            this.studentMapper = studentMapper;
            groupMapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupInfoViewModel>()).CreateMapper();
        }

        [HttpGet("GetStudents/{groupId}")]
        public IEnumerable<StudentViewModel> GetStudents(int groupId)
        {
            var bStudents = groupService.GetStudentsByGroupId(groupId);

            var students = studentMapper.Map(bStudents);
                
                //new List<StudentViewModel>
            //{
            //    new StudentViewModel {Id = 4, FullName = "John Smith"},
            //    new StudentViewModel {Id = 5, FullName = "John Smith"}
            //};

            return students;
        }

        //[HttpGet("getgroups/page={page}/count={count}")]
        //public List<GroupInfoViewModel> GetListOfGroup(int page, int count, string orderby = "Name")
        //{
        //    int skip = (page - 1) * count;
        //    var groups = groupMapper.Map<IEnumerable<GroupDTO>, List<GroupInfoViewModel>>(groupService.GetAll(orderby, skip, count));
        //    return groups;
        //}

        //[HttpGet("getgroupsfilters/page={page}/count={count}")]
        //public List<GroupInfoViewModel> GetListOfGroup(
        //    int page,
        //    int count,
        //    string orderby = "Name",
        //    string name = "",
        //    DateTime? startdate = null,
        //    DateTime? enddate = null,
        //    int? cityid = null,
        //    int? directionid = null,
        //    int? technologyid = null,
        //    int? stageid = null)
        //{
        //    int skip = (page - 1) * count;
        //    var groups = groupMapper.Map<IEnumerable<GroupDTO>, List<GroupInfoViewModel>>(groupService.GetAll(orderby, skip, count, name, startdate, enddate, cityid, directionid, technologyid, stageid));
        //    return groups;
        //}
    }
}