using Google.Cloud.Diagnostics.Common;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace aspnetapp.Filters
{
        public class ExceptionFilter : IExceptionFilter
        {
            private readonly IExceptionLogger _logger;
        
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