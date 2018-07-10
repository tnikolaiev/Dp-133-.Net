using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Ras.Web.Filters
{
    public class LoggerFilterAttribute : Attribute, IActionFilter
    {
        private readonly ILogger logger;
        public LoggerFilterAttribute(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger("Controller");           
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation($" {context.ActionDescriptor.DisplayName} executing");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation($" {context.ActionDescriptor.DisplayName} executed");
        }
    }
}