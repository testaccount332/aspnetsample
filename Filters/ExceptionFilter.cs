using Google.Cloud.Diagnostics.Common;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace aspapp2.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IExceptionLogger _log;
        
        public ExceptionFilter(IExceptionLogger log)
        {
            _log = log;
        }
        
        public void OnException(ExceptionContext context)
        {
            _log.Log(context.Exception);
        }
    }
}
