using Microsoft.Extensions.Logging;
using Ras.BLL.DTO;

namespace Ras.BLL.Implementation.Proxies.Logging
{
    public class DictionariesFeedbackServiceLogProxy : IDictionariesFeedbackService
    {
        private readonly IDictionariesFeedbackService dictionariesFeedbackService;
        private readonly ILogger logger;

        public DictionariesFeedbackServiceLogProxy(IDictionariesFeedbackService dictionariesFeedbackService, ILogger logger)
        {
            this.logger = logger;
            this.dictionariesFeedbackService = dictionariesFeedbackService;
        }

        public DictionariesFeedbackDTO GetFeedbackDictionaries()
        {
            logger.Log(LogLevel.Trace, $"Begin DictionariesFeedbackService.GetFeedbackDictionaries()");
            var result = dictionariesFeedbackService.GetFeedbackDictionaries();
            logger.Log(LogLevel.Trace, $"End DictionariesFeedbackService.GetFeedbackDictionaries()");

            return result;
        }
    }
}