using System.Net;
using Hr.LeaveManagement.Api.Models;
using HRLeaveManagement.Application.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;
using BadRequestException = HRLeaveManagement.Application.Exceptions.BadRequestException;
using NotFoundException = HRLeaveManagement.Application.Exceptions.NotFoundException;

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
            CustomProblemDetail problem = new();

            switch (ex)
            {
                case BadRequestException badHttpRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    problem = new CustomProblemDetail
                    {
                        Title = badHttpRequestException.Message,
                        Status = (int)statusCode,
                        Detail = badHttpRequestException.InnerException?.Message,
                        Type = nameof(BadHttpRequestException),
                        Errors = badHttpRequestException.ValidationErrors

                    };
                    break;
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    problem = new CustomProblemDetail()
                    {
                        Title = notFoundException.Message,
                        Status = (int)statusCode,
                        Type = nameof(NotFoundException),
                        Detail = notFoundException.InnerException?.Message

                    };
                    break;
                default:
                    problem = new CustomProblemDetail()
                    {
                        Title = ex.Message,
                        Status = (int)statusCode,
                        Type = nameof(HttpStatusCode.InternalServerError),
                        Detail = ex.StackTrace
                    };
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
