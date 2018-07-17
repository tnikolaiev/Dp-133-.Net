using System;
using Microsoft.AspNetCore.Mvc;
using Ras.BLL;
using Ras.Web.Models;
using AutoMapper;
using Ras.BLL.DTO;
using Ras.Web.Filters;

namespace Web.Controllers
{
    [ServiceFilter(typeof(LoggerFilterAttribute))]
    [ServiceFilter(typeof(CustomExeptionFilterAttribute))]
    [Route("api/[controller]")]
    public class GroupInfoController : Controller
    {
        IGroupService groupService;
        IDictionariesGroupService dictionariesService;
        IMapper groupMapper;
        IMapper groupDtoMapper;

        public GroupInfoController(IGroupService serviceGroup, IDictionariesGroupService serviceDictionaries)
        {
            groupService = serviceGroup;
            dictionariesService = serviceDictionaries;
            groupMapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupInfoViewModel>()).CreateMapper();
            groupDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupInfoViewModel, GroupDTO>()).CreateMapper();
        }

        [HttpGet("groupInfo/{groupId}")]
        public IActionResult GetGroupInfo(int groupId)
        {
            try
            {
                var group = groupMapper.Map<GroupDTO, GroupInfoViewModel>(groupService.GetById(groupId));
                var dictionaries = dictionariesService.GetGroupInfoDictionaries();
                MapDictionaryFromDto(group, dictionaries);
                return Ok(group);
            }
            catch(ArgumentException)
            {
                return NotFound();
            }
        }

        [Route("editGroup")]
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

        [Route("createGroup")]
        [HttpPost]
        public IActionResult CreateGroup([FromBody] GroupInfoViewModel group)
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

        [Route("getEmployees/{groupId}")]
        [HttpGet]
        public IActionResult GetEmployeesForGroup(int groupId)
        {
            return Ok();
        }

        [Route("removeEmployeeFromGroup/{groupId}")]
        [HttpGet]
        public IActionResult RemoveEmployeeFromGroup(int employeeId, int groupId)
        {
            return Ok();
        }

        [Route("addEmployeeToGroup/{groupId}")]
        [HttpGet]
        public IActionResult AddEmployeeToGroup(int employeeId, int groupId)
        {
            return Ok();
        }

        [Route("updateEmployeeInGroup/{groupId}")]
        [HttpGet]
        public IActionResult UpdateEmployeeInGroup()
        {
            //TODO Create Teacher View Model
            //var r = new EmployeeDTO();
            return Ok();
        }

        private void MapDictionaryFromDto(GroupInfoViewModel model, DictionariesGroupDTO dictionaries)
        {
            model.Cities = dictionaries.Cities;
            model.Directions = dictionaries.Directions;
            model.PaymentStatuses = dictionaries.PaymentStatuses;
            model.Profiles = dictionaries.Profiles;
            model.Stages = dictionaries.Stages;
            model.Technologies = dictionaries.Technologies;
        }
    }
}