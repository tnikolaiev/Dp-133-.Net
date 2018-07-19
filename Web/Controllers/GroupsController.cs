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

        public GroupsController(IGroupService groupService)
        {
            this.groupService = groupService;
            this.groupMapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupInfoViewModel>()).CreateMapper();
        }

        /// <summary>
        /// Get sorted list of group with paging
        /// </summary>
        /// <param name="pageNumber">Current page</param>
        /// <param name="amountItem">Number of items per page</param>
        /// <param name="orderBy">Parameter for sorting</param>
        /// <returns>List of Group</returns>
        [HttpGet("getGroups/page={pageNumber}/amount={amountItem}")]
        public List<GroupInfoViewModel> GetListOfGroup(int pageNumber, int amountItem, string orderBy = "Name")
        {
            int skip = (pageNumber - 1) * amountItem;
            var groups = groupMapper.Map<IEnumerable<GroupDTO>, List<GroupInfoViewModel>>(groupService.GetAll(orderBy, skip, amountItem));
            return groups;
        }

        /// <summary>
        /// Get sorted list of group with paging and filters
        /// </summary>
        /// <param name="pageNumber">Current page</param>
        /// <param name="amountItem">Number of items per page</param>
        /// <param name="orderBy">Parameter for sorting</param>
        /// <param name="name">Parameter for filtering</param>
        /// <param name="startDate">Parameter for filtering</param>
        /// <param name="endDate">Parameter for filtering</param>
        /// <param name="cityId">Parameter for filtering</param>
        /// <param name="directionId">Parameter for filtering</param>
        /// <param name="technologyId">Parameter for filtering</param>
        /// <param name="stageId">Parameter for filtering</param>
        /// <returns></returns>
        [HttpGet("getGroupsFilters/page={pageNumber}/amount={amountItem}")]
        public List<GroupInfoViewModel> GetListOfGroup(
            int pageNumber,
            int amountItem,
            string orderBy = "Name",
            string name = "",
            DateTime? startDate = null,
            DateTime? endDate = null,
            int? cityId = null,
            int? directionId = null,
            int? technologyId = null,
            int? stageId = null)
        {
            int skip = (pageNumber - 1) * amountItem;
            var groups = groupMapper.Map<IEnumerable<GroupDTO>, List<GroupInfoViewModel>>(groupService.GetAll(orderBy, skip, amountItem, name, startDate, endDate, cityId, directionId, technologyId, stageId));
            return groups;
        }
    }
}