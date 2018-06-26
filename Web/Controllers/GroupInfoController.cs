using System;
using Microsoft.AspNetCore.Mvc;
using Ras.BLL;
using Ras.Web.Models;
using AutoMapper;
using Ras.BLL.DTO;

namespace Web.Controllers
{
    [Route("api/[controller]")]
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

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetGroupInfo(int id)
        {
            try
            {
                var group = groupMapper.Map<GroupDTO, GroupInfoViewModel>(groupService.GetById(id));
                return Ok(group);
            }
            catch(ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult EditGroupInfo([FromBody] GroupInfoViewModel group)
        {
            try
            {
                var groupForEdit = groupDtoMapper.Map<GroupInfoViewModel, GroupDTO>(group);
                groupService.Update(groupForEdit);
                return Ok();
            }
            catch(Exception)
            {
                return BadRequest(group);
            }
        }

        [HttpPost]
        public IActionResult AddGroupInfo([FromBody] GroupInfoViewModel group)
        {
            try
            {
                var groupNew = groupDtoMapper.Map<GroupInfoViewModel, GroupDTO>(group);
                groupService.Create(groupNew);
                return Ok();
            }
            catch(Exception)
            {
                return BadRequest(group);
            }
        }
    }
}