using System;
using Google.Cloud.Diagnostics.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aspapp2.Controllers
{
    public class HomeController : Controller
    {
          private readonly ILogger _logger;
        private readonly IExceptionLogger _exceptionLogger;
        
        public HomeController(ILoggerFactory loggerFactory, IExceptionLogger exceptionLogger)
        {
            _logger = loggerFactory.CreateLogger<HomeController>();
            _exceptionLogger = exceptionLogger;
        }
        public IActionResult Index()
        {
                try
                {
                    throw new Exception("this is shiiite");
                }
                catch (Exception ex)
                {
                    _exceptionLogger.Log(ex);
                }
                return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            
            return View();
        }

        public IActionResult Contact()
        {
            throw new Exception("did this do");
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
