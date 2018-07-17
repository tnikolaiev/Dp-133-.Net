using Microsoft.Extensions.Logging;
using Ras.BLL;
using Ras.BLL.DTO;

namespace Ras.Infastructure.BLL.Proxies.Logging
{
    public class DictionariesGroupServiceLogProxy : ServiceLogProxy<IDictionariesGroupService>, IDictionariesGroupService
    {
        public DictionariesGroupServiceLogProxy
            (IDictionariesGroupService dictionariesGroupService, ILogger logger)
            : base(dictionariesGroupService, logger)
        {
        }

        public DictionariesGroupDTO GetGroupInfoDictionaries()
        {
            LogBegin();
            var result = service.GetGroupInfoDictionaries();
            LogEnd();

            return result;
        }
    }
}