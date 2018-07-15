using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Ras.BLL;
using Ras.BLL.DTO;

namespace Web.Controllers
{
    [Route("api/view-groupinfo")]
    [ApiController]
    public class AcademyController : ControllerBase
    {
        private IGroupService _groupService;

        public AcademyController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        // GET: api/view-groupinfo
        [HttpGet]
        public IEnumerable<GroupDTO> Get()
        {
            // TODO Fix method arguments
            //var result = _groupService.GetAll();
            //return result.Take(10);
            return null;
        }
    }
}
