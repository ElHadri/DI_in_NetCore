using Microsoft.AspNetCore.Mvc.Filters;

using System.Diagnostics;

namespace WebApplication2.Interceptors.Filters
{
    public class SomeFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something.
            Debug.WriteLine("**************************************************");
            Debug.WriteLine("Begin - Local filter..........");

        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something.
            Debug.WriteLine("End - Local filter..........");
            Debug.WriteLine("**************************************************");

        }
    }
}
