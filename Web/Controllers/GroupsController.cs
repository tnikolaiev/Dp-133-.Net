using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ras.BLL;
using Ras.BLL.DTO;

namespace Web.Controllers
{
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

        public IActionResult Index()
        {
            return View();
        }

        public List<GroupInfoViewModel> GetListOfGroup()
        {
            var groups = groupMapper.Map<IEnumerable<GroupDTO>, List<GroupInfoViewModel>>(groupService.GetAll());
            return groups;
        }

        [HttpPost]
        public List<GroupInfoViewModel> GetListOfGroup(
            string name = "",
            DateTime? startdate = null,
            DateTime? enddate = null,
            int? cityid = null,
            int? directionid = null,
            int? technologyid = null,
            int? stageid = null)
        {
            var groups = groupMapper.Map<IEnumerable<GroupDTO>, List<GroupInfoViewModel>>(groupService.GetAll(name, startdate, enddate, cityid, directionid, technologyid, stageid));
            return groups);
        }
    }
}