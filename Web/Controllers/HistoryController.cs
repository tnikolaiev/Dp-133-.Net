using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Ras.BLL;
using Ras.BLL.DTO;
using Ras.Infastructure.Mapping;
using Ras.Web.Models;

namespace Web.Controllers
{
    [Route("api/history"), ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IGroupHistoryService _historyService;
        private readonly ITypeMapper<GroupHistoryDTO, GroupHistoryViewModel> _mapper;

        public HistoryController( IGroupHistoryService historyService
                                , ITypeMapper<GroupHistoryDTO, GroupHistoryViewModel> mapper)
        {
            _historyService = historyService;
            _mapper = mapper;
        }

        [HttpGet("findAll/{academyId}")]
        public IEnumerable<GroupHistoryViewModel> FindAll(int academyId)
        {
            var items = _historyService.GetAll(academyId);
            var viewModels = _mapper.Map(items);
            return viewModels;
        }
    }
}
