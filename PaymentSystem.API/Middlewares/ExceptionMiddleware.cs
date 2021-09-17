using Microsoft.AspNetCore.Http;
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

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext context) 
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
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
