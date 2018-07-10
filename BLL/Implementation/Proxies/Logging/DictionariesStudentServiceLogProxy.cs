using Microsoft.Extensions.Logging;
using Ras.BLL.DTO;

namespace Ras.BLL.Implementation.Proxies.Logging
{
    public class DictionariesStudentServiceLogProxy : IDictionariesStudentService
    {
        private readonly IDictionariesStudentService dictionariesStudentService;
        private readonly ILogger logger;

        public DictionariesStudentServiceLogProxy(IDictionariesStudentService dictionariesStudentService, ILogger logger)
        {
            this.logger = logger;
            this.dictionariesStudentService = dictionariesStudentService;
        }

        public DictionariesStudentDTO GetStudentDictionaries(int groupId)
        {
            logger.Log(LogLevel.Trace, $"Begin DictionariesStudentService.GetStudentDictionaries()");
            var result = dictionariesStudentService.GetStudentDictionaries(groupId);
            logger.Log(LogLevel.Trace, $"End DictionariesStudentService.GetStudentDictionaries()");

            return result;
        }
    }
}