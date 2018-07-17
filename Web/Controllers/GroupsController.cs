//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using Ras.BLL;
//using Ras.BLL.DTO;
//using Ras.Web.Models;

//namespace Web.Controllers
//{
//    [Route("api/[controller]")]
//    public class GroupsController : Controller
//    {
//        IGroupService groupService;
//        IMapper groupMapper;

//        public GroupsController(IGroupService groupService)
//        {
//            this.groupService = groupService;
//            this.groupMapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupInfoViewModel>()).CreateMapper(); 
//        }

//        [HttpGet("getgroups/page={page}/count={count}")]
//        public List<GroupInfoViewModel> GetListOfGroup(int page, int count, string orderby="Name")
//        {
//            int skip = (page - 1) * count;
//            var groups = groupMapper.Map<IEnumerable<GroupDTO>, List<GroupInfoViewModel>>(groupService.GetAll(orderby, skip, count));
//            return groups;
//        }

//        [HttpGet("getgroupsfilters/page={page}/count={count}")]
//        public List<GroupInfoViewModel> GetListOfGroup(
//            int page, 
//            int count, 
//            string orderby="Name",
//            string name = "",
//            DateTime? startdate = null,
//            DateTime? enddate = null,
//            int? cityid = null,
//            int? directionid = null,
//            int? technologyid = null,
//            int? stageid = null)
//        {
//            int skip = (page - 1) * count;
//            var groups = groupMapper.Map<IEnumerable<GroupDTO>, List<GroupInfoViewModel>>(groupService.GetAll(orderby, skip, count, name, startdate, enddate, cityid, directionid, technologyid, stageid));
//            return groups;
//        }
//    }
//}