using Google.Cloud.Diagnostics.Common;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace aspapp2.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger _log;
        
        public ExceptionFilter(ILogger<ExceptionFilter> log)
        {
            _log = log;
        }
        
        public void OnException(ExceptionContext context)
        {
            _log.LogError(500, context.Exception, context.Exception.Message);
            context.ExceptionHandled = true;
        }
    }
}
