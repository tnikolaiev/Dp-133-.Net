using Microsoft.Extensions.Logging;
using Ras.BLL.DTO;

namespace Ras.BLL.Implementation.Proxies.Logging
{
    public class DictionariesFeedbackServiceLogProxy : ServiceLogProxy<IDictionariesFeedbackService>, IDictionariesFeedbackService
    {
        public DictionariesFeedbackServiceLogProxy(IDictionariesFeedbackService dictionariesFeedbackService, ILogger logger): base(dictionariesFeedbackService,logger)
        {
        }

        public DictionariesFeedbackDTO GetFeedbackDictionaries()
        {
            LogBegin();
            var result = service.GetFeedbackDictionaries();
            LogEnd();

            return result;
        }
    }
}