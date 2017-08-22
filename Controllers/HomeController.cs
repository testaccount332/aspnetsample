using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Diagnostics.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;

namespace aspnetapp.Controllers
{
    public class HomeController : Controller
    {   
        private readonly IExceptionLogger _logger;
        private readonly ILogger _log;
        private readonly IManagedTracer _tracer;
        
        public HomeController(IExceptionLogger exceptionLogger, ILoggerFactory loggerFactory, IManagedTracer tracer)
        {
            _log = loggerFactory.CreateLogger<HomeController>();
            _logger = exceptionLogger;
            _tracer = tracer;
        }
        
        public IActionResult Index()
        {
            using (_tracer.StartSpan(nameof(Index)))
            {
                return View();
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            
            using (_tracer.StartSpan(nameof(Index)))
            {
                try
                {
                    throw new Exception("this is shiiite");
                }
                catch (Exception ex)
                {
                    _log.LogInformation("hello friends");
                    _logger.Log(ex, this.HttpContext);
                }
                
                return View();
            }
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
