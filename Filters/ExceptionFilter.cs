using Google.Cloud.Diagnostics.Common;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace aspnetapp.Filters
{
        public class ExceptionFilter : IExceptionFilter
        {
            private readonly IExceptionLogger _logger;
            private readonly ILogger _log;
        
            public ExceptionFilter(IExceptionLogger exceptionLogger, ILogger logger)
            {
                _logger = exceptionLogger;
                _log = logger;
            }
        
            public void OnException(ExceptionContext context)
            {
                _log.LogError("fuck that");

                _logger.Log(context.Exception, context.HttpContext);
            }
        }
}