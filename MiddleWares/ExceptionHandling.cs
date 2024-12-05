using System.Net;

namespace School_Management_System.MiddleWares
{
    public class ExceptionHandling
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandling> _exception;

        public ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> exception)
        {
            _next = next;
            _exception = exception;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _exception.LogError(ex.ToString());
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsync(ex.ToString());
            }
        }

    }
}
