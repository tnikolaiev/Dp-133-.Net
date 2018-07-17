using System.Collections.Generic;
using Ras.BLL.DTO;

namespace Ras.BLL
{
    public interface IGroupHistoryService
    {
        IEnumerable<GroupHistoryDTO> GetAll(int groupId);
    }
}
