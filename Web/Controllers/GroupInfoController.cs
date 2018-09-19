using System;
using Microsoft.AspNetCore.Mvc;
using Ras.BLL;
using Ras.Web.Models;
using AutoMapper;
using Ras.BLL.DTO;
using Ras.Web.Filters;
using System.Linq;

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
        IMapper employeeMapper;
        IMapper employeeDtoMapper;

        public GroupInfoController(IGroupService serviceGroup, IDictionariesGroupService serviceDictionaries)
        {
            groupService = serviceGroup;
            dictionariesService = serviceDictionaries;
            groupMapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupInfoViewModel>()).CreateMapper();
            groupDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupInfoViewModel, GroupDTO>()).CreateMapper();
            employeeMapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeDTO, EmployeeViewModel>()).CreateMapper();
            employeeDtoMapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeeViewModel, EmployeeDTO>()).CreateMapper();
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
            try
            {
                var employees = groupService.GetAllEmployeesForGroup(groupId).Select(x=> employeeMapper.Map<EmployeeDTO, EmployeeViewModel>(x));
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("removeEmployeeFromGroup/{groupId}/{employeeId}")]
        [HttpPost]
        public IActionResult RemoveEmployeeFromGroup(int groupId, int employeeId)
        {
            try
            {
                groupService.DeleteEmployeeFromGroup(groupId, employeeId);
                return Ok();
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [Route("addEmployeeToGroup/{groupId}/{employeeId}/{timeInvolved}/{typeId}")]
        [HttpPost]
        public IActionResult AddEmployeeToGroup(int groupId, int employeeId, int timeInvolved, int typeId)
        {
            try
            {
                groupService.AddEmployeeToGroup(groupId, employeeId, timeInvolved, typeId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("updateEmployeeInGroup")]
        [HttpPost]
        public IActionResult UpdateEmployeeInGroup([FromBody] EmployeeViewModel employee)
        {
            try
            {
                groupService.UpdateEmployeeInGroup(employeeDtoMapper.Map<EmployeeViewModel, EmployeeDTO>(employee));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(employee);
            }
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