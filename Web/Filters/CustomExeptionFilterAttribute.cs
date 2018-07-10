using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Ras.Web.Filters
{
    public class CustomExeptionFilterAttribute : Attribute, IExceptionFilter
    {
        private readonly ILogger logger;

        public CustomExeptionFilterAttribute(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger("Controller");
        }

        public void OnException(ExceptionContext context)
        {
            context.Result = new ContentResult
            {
                Content = context.Exception.Message
            };
            context.ExceptionHandled = true;
            logger.LogError(context.Exception.Message);
        }
    }
}

