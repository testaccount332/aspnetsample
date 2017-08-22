using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace aspnetapp.Filters
{
        public class ExceptionFilter : IExceptionFilter
        {
            private readonly ILogger _logger;
        
            public ExceptionFilter(ILogger<ExceptionFilter> logger)
            {
                _logger = logger;
            }
        
            public void OnException(ExceptionContext context)
            {
                _logger.LogError(500, context.Exception, context.Exception.Message);
            }
        }
}