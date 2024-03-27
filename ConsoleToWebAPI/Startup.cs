using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ConsoleToWebAPI
{
    public class Startup
    {
        //3rd Step: Create this to methods
        public void ConfigureServices(IServiceCollection services)
        {
            //4rd step to make empty to web api
            services.AddControllers();

            //injecting the CustomMiddleware
            services.AddTransient<CuustomMiddleware>();
        }

        // Middlewares
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from Use-1 1\n");
            //    await next(); //it's going to call the next Method 

            //    await context.Response.WriteAsync("Hello From use-1 2\n");//it will execute after next method executation
            //});

            ////using the CuustomMiddleware here
            //app.UseMiddleware<CuustomMiddleware>();

            //app.Map("/sohan", CustomCode);

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from Use-2 1\n");
            //    await next(); //it's going to call the next Method 

            //    await context.Response.WriteAsync("Hello From use-2 2\n");//it will execute after next method executation
            //});

            

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Hello from Run \n");
            //});



            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting(); //inabling the Routing in this methods

            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); //5th Step
            });

            
        }

        private void CustomCode(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello form CustomCode app sohan\n");
                await next();
                //here next will not work
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello form CustomCode app sohan2\n");
                //here next will not work
            });
        }
    }
}
