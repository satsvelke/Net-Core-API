using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ViewModel;
/// <summary>
/// deprecated, replaced by custom exception middleware 
/// </summary>
namespace Service.Filters
{
    public partial class ExceptionFilter : IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            var errorList = new List<string>();
            errorList.Add("No Validation Error Occurred");

            var errors = new Errors()
            {
                ErrorList = errorList
            };
            var errorsMessage = new ErrorMessage()
            {
                type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                title = "Internal Server Error",
                status = 500,
                traceId = Guid.NewGuid().ToString(),
                errors = errors
            };

            context.Result = new ObjectResult(errorsMessage)
            {
                StatusCode = 500
            };

            return Task.CompletedTask;
        }
    }
}