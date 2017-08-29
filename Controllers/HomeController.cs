using System;
using aspapp2.Filters;
using Google.Cloud.Diagnostics.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace aspapp2.Controllers
{
    public class HomeController : Controller
    {
          private readonly ILogger _logger;
        
        public HomeController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HomeController>();
        }
        public IActionResult Index()
        {
           return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            
            return View();
        }

        public IActionResult Contact()
        {
            throw new CardExistsException("did this do");
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
