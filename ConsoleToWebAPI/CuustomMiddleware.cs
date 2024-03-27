using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ConsoleToWebAPI
{
    public class CuustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Hello from Custom-1 1\n");
            await next(context); //it's going to call the next Method 

            await context.Response.WriteAsync("Hello From Custom-1 2\n");
        }
    }
}
