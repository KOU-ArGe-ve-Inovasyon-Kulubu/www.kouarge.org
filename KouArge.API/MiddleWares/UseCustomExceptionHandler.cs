using KouArge.Core.DTOs;
using KouArge.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System.Text.Json;

namespace KouArge.API.MiddleWares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
      
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

      
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

 
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        UnAuthorizedException=>401,
                        ForbiddenException=>403,
                        NotFoundException => 404,
                        _ => 500
                    };
                    //_ -> default 

                    if(statusCode==403)
                    {
                        var httpContext = context.Response.HttpContext;

                        var routeData = httpContext.GetRouteData();
                        var actionContext = new ActionContext(httpContext, routeData, new ActionDescriptor());

                        var data = CustomResponseDto<NoContentDto>.Fail(401, "Admin Yetkisiz giriş.", 3);

                        var result = new ObjectResult(data) { StatusCode = statusCode };
                        await result.ExecuteResultAsync(actionContext);
                    }

                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });
            });
        }
    }
}
