using Microsoft.Extensions.Logging;
using Ras.BLL;
using Ras.BLL.DTO;

namespace Ras.Infastructure.BLL.Proxies.Logging
{
    public class DictionariesStudentServiceLogProxy : ServiceLogProxy<IDictionariesStudentService>, IDictionariesStudentService
    {
        public DictionariesStudentServiceLogProxy
            (IDictionariesStudentService dictionariesStudentService, ILogger logger)
            : base(dictionariesStudentService, logger)
        {
        }

        public DictionariesStudentDTO GetStudentDictionaries(int groupId)
        {
            LogBegin(groupId);
            var result = service.GetStudentDictionaries(groupId);
            LogEnd(groupId);

            return result;
        }
    }
}