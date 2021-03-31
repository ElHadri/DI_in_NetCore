using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using WebApplication2.Interceptors.Filters;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // [TypeFilter(typeof(SomeFilter))] --> get the filter instance dynamically through "TypeFilter", 
        // So we don't need to register "SomeFilter" in the entry point of the app;

        // "ServiceFilter" finds the filter instance from the service collection; if you don't register it, it will definitely throw an exception.
        [ServiceFilter(typeof(SomeFilter))]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ServicesAvailable()
        {
            ViewData["Services"] = Startup._services;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
