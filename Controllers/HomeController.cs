﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Logging;
using Google.Cloud.Diagnostics.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace aspnetapp.Controllers
{
    public class HomeController : Controller
    {   
        private readonly IExceptionLogger _logger;
        private readonly ILogger _log;
        
        public HomeController(IExceptionLogger exceptionLogger)
        {
            _logger = exceptionLogger;
        }
        
        public IActionResult Index()
        {
            throw new Exception("faahssds");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            
            try
            {
                throw new Exception("this is shiiite");
            }
            catch (Exception ex)
            {
                _log.Debug("hello friends");
                _logger.Log(ex, this.HttpContext);
            }

            return View();
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
