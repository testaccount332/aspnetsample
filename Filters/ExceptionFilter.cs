using Google.Apis.Logging;
using Google.Cloud.Diagnostics.Common;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspnetapp.Filters
{
        public class ExceptionFilter : IExceptionFilter
        {
            private readonly IExceptionLogger _logger;
            private readonly ILogger _log;
        
            public ExceptionFilter(IExceptionLogger exceptionLogger)
            {
                _logger = exceptionLogger;
            }
        
            public void OnException(ExceptionContext context)
            {
                _logger.Log(context.Exception, context.HttpContext);
            }
        }
}