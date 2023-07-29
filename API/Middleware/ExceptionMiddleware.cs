using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

//this middleware handles server error throwed in BuggyController.cs

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, 
            IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
        }


//we have to implement this function in all customized middleware, it will called by .net framework in background
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);//just call the next middleware in the middleware tree
                //for more knowledge of .net middleware: 
                //https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-7.0
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                //because we are out side of api controller, we need to specify
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                var response = new ProblemDetails
                {
                    Status = 500,
                    Detail = _env.IsDevelopment() ? ex.StackTrace?.ToString() : null,
                    Title = ex.Message
                };

                var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase};

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}