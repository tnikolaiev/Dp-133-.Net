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
        ///     Gets list of all groups, sorted by <paramref name="orderBy" />, and returns list with count of items equals
        ///     <paramref name="itemsPerPage" /> on page with number <paramref name="pageNumber" />. Is used for displaing groups
        ///     on UI with paging.
        /// </summary>
        /// <param name="pageNumber">Page number in list of all groups. Count of all pages depends on <paramref name="itemsPerPage" />.</param>
        /// <param name="itemsPerPage">Count of items will be displayed on page.</param>
        /// <param name="orderBy">PName of field by which list be sorted.</param>
        /// <returns>List of Group</returns>
        [HttpGet("getGroups/page={pageNumber}/itemsPerPage={itemsPerPage}")]
        public List<GroupInfoViewModel> GetPagedListOfGroups(int pageNumber, int itemsPerPage, string orderBy = "Name")
        {
            int skip = (pageNumber - 1) * itemsPerPage; // TODO move to BLL
            var groups = groupMapper.Map<IEnumerable<GroupDTO>, List<GroupInfoViewModel>>(groupService.GetAll(orderBy, skip, itemsPerPage));
            return groups;
        }

        /// <summary>
        ///     Gets list of all groups, filtered by givenValues and sorted by <paramref name="orderBy" />, and returns list with count of items equals
        ///     <paramref name="itemsPerPage" /> on page with number <paramref name="pageNumber" />. Is used for displaing groups
        ///     on UI with paging.
        /// </summary>
        /// <param name="pageNumber">Page number in list of all groups. Count of all pages depends on <paramref name="itemsPerPage" />.</param>
        /// <param name="itemsPerPage">Count of items will be displayed on page.</param>
        /// <param name="orderBy">Parameter for sorting</param>
        /// <param name="name">Parameter for filtering</param>
        /// <param name="startDate">Parameter for filtering</param>
        /// <param name="endDate">Parameter for filtering</param>
        /// <param name="cityId">Parameter for filtering</param>
        /// <param name="directionId">Parameter for filtering</param>
        /// <param name="technologyId">Parameter for filtering</param>
        /// <param name="stageId">Parameter for filtering</param>
        /// <returns></returns>
        [HttpGet("getGroupsFilters/page={pageNumber}/itemsPerPage={itemsPerPage}")]
        public List<GroupInfoViewModel> GetPagedListOfGroup(
            int pageNumber,
            int itemsPerPage,
            string orderBy = "Name",
            string name = "",
            DateTime? startDate = null,
            DateTime? endDate = null,
            int? cityId = null,
            int? directionId = null,
            int? technologyId = null,
            int? stageId = null)
        {
            int skip = (pageNumber - 1) * itemsPerPage; // TODO move to BLL
            var groups = groupMapper.Map<IEnumerable<GroupDTO>, List<GroupInfoViewModel>>(groupService.GetAll(orderBy, skip, itemsPerPage, name, startDate, endDate, cityId, directionId, technologyId, stageId));
            return groups;
        }
    }
}