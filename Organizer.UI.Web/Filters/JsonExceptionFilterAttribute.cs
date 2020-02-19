using System.Data.Entity.Core.Metadata.Edm;
using System.Web.Mvc;

namespace Organizer.UI.Web.Filters
{
    public class JsonExceptionFilterAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled)
            {
                var result = new JsonResult();
                result.Data = new {Message = exceptionContext.Exception.ToString()};
                exceptionContext.Result = result;
                
                exceptionContext.HttpContext.Response.StatusCode = 500;

                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}