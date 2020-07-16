using EnqueteApi.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace bdiApi.Filtros
{
    public class ExceptionHandlerFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is BusinessException)
            {
                var statusCode = (int)HttpStatusCode.BadRequest;

                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = statusCode;

                if (context.Exception is BusinessException)
                {
                    var businessException = (BusinessException)context.Exception;

                    context.Result = new JsonResult(new
                    {
                        error = businessException?.Message
                    });
                }

                return;
            }

            var code = HttpStatusCode.InternalServerError;

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;

            context.Result = new JsonResult(new
            {
                error = context.Exception.Message,
                stackTrace = context.Exception.StackTrace
            });
        }
    }
}
