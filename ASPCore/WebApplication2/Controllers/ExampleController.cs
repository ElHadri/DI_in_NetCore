using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication2.Interfaces;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class ExampleController : Controller
    {
        private readonly ExampleService _exampleService;
        private readonly IExampleTransient _transientExample;
        private readonly IExampleScoped _scopedExample;
        private readonly IExampleSingleton _singletonExample;
        private readonly IExampleSingletonInstance _singletonInstanceExample;

        public ExampleController(
            ExampleService ExampleService,
            IExampleTransient transientExample,
            IExampleScoped scopedExample,
            IExampleSingleton singletonExample,
            IExampleSingletonInstance singletonInstanceExample)
        {
            _exampleService = ExampleService;
            _transientExample = transientExample;
            _scopedExample = scopedExample;
            _singletonExample = singletonExample;
            _singletonInstanceExample = singletonInstanceExample;
        }

        public IActionResult Index()
        {
            // viewbag contains controller-requested services
            ViewBag.Transient = _transientExample;
            ViewBag.Scoped = _scopedExample;
            ViewBag.Singleton = _singletonExample;
            ViewBag.SingletonInstance = _singletonInstanceExample;

            // Example service has its own requested services
            ViewBag.Service = _exampleService;

            return View();
        }

        public IActionResult SingletonDependencies()
        {
            ViewBag.Singleton = _singletonExample;
            ViewBag.Service = _exampleService;
            return View();
        }

        public IActionResult ScopedDependencies()
        {
            ViewBag.Scoped = _scopedExample;
            ViewBag.Service = _exampleService;
            return View();
        }

        public IActionResult TransientDependencies()
        {
            ViewBag.Transient = _transientExample;
            ViewBag.Service = _exampleService;
            return View();
        }
    }
}

