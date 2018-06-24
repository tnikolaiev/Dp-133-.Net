using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ras.BLL;
using Ras.Web.Models;
using AutoMapper;
using Ras.BLL.DTO;

namespace Web.Controllers
{
    public class GroupInfoController : Controller
    {
        IGroupService groupService;
        IMapper groupMapper;
        IMapper groupDtoMapper;

        public GroupInfoController(IGroupService service)
        {
            groupService = service;
            groupMapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupInfoViewModel>()).CreateMapper();
            groupDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupInfoViewModel, GroupDTO>()).CreateMapper();
        }

        //return Create ViewModel object?
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public GroupInfoViewModel GetGroupInfo(int id)
        {
            var group = groupMapper.Map<GroupDTO, GroupInfoViewModel>(groupService.GetById(id));
            return group;
        }

        [HttpPost]
        public void EditGroupInfo([FromBody] GroupInfoViewModel group)
        {
            var groupForEdit = groupDtoMapper.Map<GroupInfoViewModel, GroupDTO>(group);
            groupService.Update(groupForEdit);
        }

        [HttpPost]
        public void AddGroupInfo([FromBody] GroupInfoViewModel group)
        {
            var groupNew = groupDtoMapper.Map<GroupInfoViewModel, GroupDTO>(group);
            groupService.Create(groupNew);
        }
    }
}