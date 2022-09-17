using KouArge.Core.DTOs;
using KouArge.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace www.kouarge.org.MiddleWares
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
                        UnAuthorizedException => 401,
                        ForbiddenException => 403,
                        NotFoundException => 404
                    };


                    if (statusCode == 401)
                        context.Response.Redirect("/Account/Login");

                    if (statusCode == 403)
                        context.Response.Redirect("/Department/Forbidden");

                    if (statusCode==404)
                        context.Response.Redirect("/Department/Error");
                });
            });
        }
    }
}
