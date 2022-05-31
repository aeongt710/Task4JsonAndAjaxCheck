using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Nancy.Json;

namespace Task4JsonAndAjaxCheck.Filters
{
    public class JsonCheckFilter : IActionFilter
    {
        public  void OnActionExecuted(ActionExecutedContext context)
        {
            StringValues value = StringValues.Empty;
            context.HttpContext.Request.Headers.TryGetValue("accept", out value);
            var str = value.ToString();
            if(value.Contains("application/json"))
            {
                var data = ((Controller)context.Controller).ViewData.Model;
                CancellationToken cancellationToken = CancellationToken.None;
                var json = new JavaScriptSerializer().Serialize(data);
                context.Result = new JsonResult(data);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
