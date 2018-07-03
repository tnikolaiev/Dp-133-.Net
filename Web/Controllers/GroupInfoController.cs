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
        IDictionariesService dictionariesService;
        IMapper groupMapper;
        IMapper groupDtoMapper;
        IMapper dictionariesMapper;

        public GroupInfoController(IGroupService serviceGroup, IDictionariesService serviceDictionaries)
        {
            groupService = serviceGroup;
            dictionariesService = serviceDictionaries;
            groupMapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupInfoViewModel>()).CreateMapper();
            groupDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupInfoViewModel, GroupDTO>()).CreateMapper();
            dictionariesMapper = new MapperConfiguration(cfg => cfg.CreateMap<DictionariesDTO, GroupInfoViewModel>()).CreateMapper();
        }

        [HttpGet("{id}")]
        public IActionResult GetGroupInfo(int id)
        {
            try
            {
                var group = groupMapper.Map<GroupDTO, GroupInfoViewModel>(groupService.GetById(id));
                group = dictionariesMapper.Map<DictionariesDTO, GroupInfoViewModel>(dictionariesService.GetGroupInfoDictionaries());
                return Ok(group);
            }
            catch(ArgumentException)
            {
                return NotFound();
            }
        }

        [Route("EditGroup")]
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

        [Route("AddGroup")]
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