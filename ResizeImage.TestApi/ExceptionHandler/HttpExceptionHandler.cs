using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using ResizeImage.Exception;

namespace ResizeImage.TestApi.ExceptionHandler
{
    public class HttpExceptionHandler :  IExceptionFilter 
    {
        private readonly IHostEnvironment _env;

        public HttpExceptionHandler(IHostEnvironment env)
        {
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            object res = new {messag = string.Empty , code = StatusCodes.Status500InternalServerError};
            var exception = context.Exception;
            if (exception is ResizeException)
            {
                var resizeException = (ResizeException)context.Exception;
                res = new
                {
                    message = resizeException.Message,
                    code = resizeException.HResult
                };

            }


            context.Result = new ObjectResult(res)
            {
                StatusCode = exception.HResult
            };
            context.ExceptionHandled = true;
        }


    }
}
