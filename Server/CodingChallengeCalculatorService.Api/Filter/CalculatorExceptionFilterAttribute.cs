using System.Net.Mime;
using CodingChallengeCalculatorService.Application.Exception;
using CodingChallengeCalculatorService.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CodingChallengeCalculatorService.Api.Filter
{
    public class CalculatorExceptionFilterAttribute : ExceptionFilterAttribute
    {
    
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is CalculatorException)
            {
                var calculatorException = (CalculatorException)context.Exception;
                context.Result = new ObjectResult(
                    new ErrorResponse
                    {
                        ErrorCode = calculatorException.Code,
                        ErrorMessage = calculatorException.Message,
                        ErrorStatus = calculatorException.StatusCode.GetHashCode()
                    });
                context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
                context.HttpContext.Response.StatusCode = calculatorException.StatusCode.GetHashCode();
            }
            else
            {
                context.Result = new ObjectResult(
                    new ErrorResponse
                    {
                        ErrorCode = "Generic Error",
                        ErrorMessage = context.Exception.Message,
                        ErrorStatus = System.Net.HttpStatusCode.InternalServerError.GetHashCode()
                    });
                context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
                context.HttpContext.Response.StatusCode = System.Net.HttpStatusCode.InternalServerError.GetHashCode();
            }

        }
    }
}
