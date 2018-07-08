using Microsoft.Extensions.Logging;
using Ras.BLL.DTO;

namespace Ras.BLL.Implementation.Proxies.Logging
{
    public class DictionariesGroupServiceLogProxy : IDictionariesGroupService
    {
        private readonly IDictionariesGroupService dictionariesGroupService;
        private readonly ILogger logger;

        public DictionariesGroupServiceLogProxy(IDictionariesGroupService dictionariesGroupService, ILogger logger)
        {
            this.logger = logger;
            this.dictionariesGroupService = dictionariesGroupService;
        }

        public DictionariesGroupDTO GetGroupInfoDictionaries()
        {
            logger.Log(LogLevel.Trace, $"Begin DictionariesGroupService.GetGroupInfoDictionaries()");
            var result = dictionariesGroupService.GetGroupInfoDictionaries();
            logger.Log(LogLevel.Trace, $"End DictionariesGroupService.GetGroupInfoDictionaries()");

            return result;
        }
    }
}