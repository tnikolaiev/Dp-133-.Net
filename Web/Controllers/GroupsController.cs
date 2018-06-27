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
        private IGroupService service;
        private IMapper mapper;

        public GroupsController(IGroupService service)
        {
            this.service = service;
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<GroupDTO, GroupInfoViewModel>()).CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var groups = mapper.Map<IEnumerable<GroupDTO>, IEnumerable<GroupInfoViewModel>>(service.GetAll());
            return Ok(groups);
        }
    }
}