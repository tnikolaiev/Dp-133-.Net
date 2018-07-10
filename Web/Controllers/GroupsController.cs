using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ras.BLL;
using Ras.BLL.DTO;
using Ras.Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class GroupsController : Controller
    {
        IGroupService groupService;
        IMapper groupMapper;
        IMapper groupDtoMapper;

        public GroupsController(IGroupService groupService, IMapper groupMapper, IMapper groupDtoMapper)
        {
            this.groupService = groupService;
            this.groupMapper = groupMapper;
            this.groupDtoMapper = groupDtoMapper;
        }

        [HttpGet("page={page}/count={count}/orderby={property}")]
        public List<GroupInfoViewModel> GetListOfGroup(int page, int count, string property)
        {
            int skip = (page - 1) * count;
            var groups = groupMapper.Map<IEnumerable<GroupDTO>, List<GroupInfoViewModel>>(groupService.GetAll(property, skip, count));
            return groups;
        }

        [HttpGet("page={page}/count={count}/orderby={property}/name={name}")]
        public List<GroupInfoViewModel> GetListOfGroup(
            int page, 
            int count, 
            string property,
            string name = "",
            DateTime? startdate = null,
            DateTime? enddate = null,
            int? cityid = null,
            int? directionid = null,
            int? technologyid = null,
            int? stageid = null)
        {
            int skip = (page - 1) * count;
            var groups = groupMapper.Map<IEnumerable<GroupDTO>, List<GroupInfoViewModel>>(groupService.GetAll(property, skip, count, name, startdate, enddate, cityid, directionid, technologyid, stageid));
            return groups;
        }
    }
}