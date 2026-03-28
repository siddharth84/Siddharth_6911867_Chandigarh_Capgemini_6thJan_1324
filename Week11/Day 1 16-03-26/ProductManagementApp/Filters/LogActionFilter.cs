using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace ProductManagementApp.Filters
{
    public class LogActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            Console.WriteLine($"Action Executing: {actionName} at {DateTime.Now}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Action Executed at {DateTime.Now}");
        }
    }
}