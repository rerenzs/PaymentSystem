using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PaymentSystem.API.Models;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaymentSystem.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong: {ex}");

                var Response = context.Response;
                Response.ContentType = "application/json";


                var result = new ErrorModel {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = ex.Message,
                    Details = ex.StackTrace
                };

                await Response.WriteAsync(JsonSerializer.Serialize(result));
            }
        
        }
    }
}
