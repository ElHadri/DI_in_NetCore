using Microsoft.AspNetCore.Mvc.Filters;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using WebApplication2.Interfaces;

namespace WebApplication2.Interceptors.Filters
{
    public class SomeGlobalFilter : IActionFilter
    {
        //public SomeGlobalFilter(ISomeService service)
        //{
        //    // Do something with the service.
        //}

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something.
            Debug.WriteLine("**************************************************");
            Debug.WriteLine("Begin - Global filter..........");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something
            Debug.WriteLine("End - Global filter..........");
            Debug.WriteLine("**************************************************");
        }
    }
}
