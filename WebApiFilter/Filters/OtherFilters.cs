
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApiFilter.Filters
{
    public class OtherFilters : IActionFilter
    {
        private void Log(string methodName, RouteData routeData)
        {
            var actionExecuting = routeData.Values["Action Executing"];
            Debug.WriteLine(actionExecuting);
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Log("OnActionExecuted", context.RouteData);
            if (context.ActionDescriptor is ControllerActionDescriptor controllerDescriptor)
            {
                var controllerName = controllerDescriptor.ControllerName;
                var actionName = controllerDescriptor.ActionName;
                //var MethodName = controllerDescriptor.MethodInfo;
              

                context.HttpContext.Response.Headers["Controller-Name"] = controllerName;
                context.HttpContext.Response.Headers["Action-Name"] = actionName;
              //  context.HttpContext.Response.Headers["Method-Name"] = MethodName.Name;
            }

            var method = context.HttpContext.Request.Method;
            context.HttpContext.Response.Headers.Add("MethodName", method);

            var scheme = context.HttpContext.Request.Scheme;
            context.HttpContext.Response.Headers.Add("schemeName", scheme);

            var port = context.HttpContext.Request.Host.Port.ToString();
            context.HttpContext.Response.Headers.Add("PortName", port);


            var host = context.HttpContext.Request.Host.ToString();
            context.HttpContext.Response.Headers.Add("HostName", host);

        }



        public void OnActionExecuting(ActionExecutingContext context)
        {
            Log("OnActionExecuted", context.RouteData);
        }
    }
}