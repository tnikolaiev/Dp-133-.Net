using Microsoft.Extensions.Logging;
using Ras.BLL;
using Ras.BLL.DTO;

namespace Ras.Infastructure.BLL.Proxies.Logging
{
    public class DictionariesFeedbackServiceLogProxy : ServiceLogProxy<IDictionariesFeedbackService>, IDictionariesFeedbackService
    {
        public DictionariesFeedbackServiceLogProxy
            (IDictionariesFeedbackService dictionariesFeedbackService, ILogger logger) : base(dictionariesFeedbackService, logger)
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