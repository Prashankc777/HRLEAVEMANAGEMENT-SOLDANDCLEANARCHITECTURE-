using System.Net;
using Hr.LeaveManagement.Api.Models;
using HRLeaveManagement.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Hr.LeaveManagement.Api.MiddleWare
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
               await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
           HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
           dynamic problem;
           switch (ex)
           {
               case BadHttpRequestException badHttpRequestException:
                   statusCode = HttpStatusCode.BadRequest;
                    problem = new CustomValidationProblemDetails
                   {
                       Title = badHttpRequestException.Message,
                       Status = (int)statusCode,
                       Detail = badHttpRequestException.InnerException?.Message,
                       Type = nameof(BadHttpRequestException),
                       //Errors = 
                      
                    };
                   break;
               case NotFoundException notFoundException:
                   problem = new ProblemDetails
                   {
                       Status = (int)HttpStatusCode.NotFound,
                       Title = "Resource Not Found",
                       Detail = notFoundException.Message
                   };
                   break;
               default:
                   break;
           }
        }
    }
}
