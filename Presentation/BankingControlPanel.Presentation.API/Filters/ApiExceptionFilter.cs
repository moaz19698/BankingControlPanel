using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using BankingControlPanel.Application.Common.Exceptions;

namespace BankingControlPanel.Presentation.API.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var statusCode = exception switch
            {
                NotFoundException => 404,
                Application.Common.Exceptions.ValidationException => 400,
                _ => 500
            };

            context.Result = new ObjectResult(new { error = exception.Message })
            {
                StatusCode = statusCode
            };

            context.ExceptionHandled = true;
        }
    }
}
