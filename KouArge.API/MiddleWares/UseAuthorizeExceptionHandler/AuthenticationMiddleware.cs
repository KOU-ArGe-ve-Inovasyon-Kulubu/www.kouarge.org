using KouArge.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KouArge.API.MiddleWares.UseAuthorizeExceptionHandler
{
    public class AuthenticationMiddleware
    {
        readonly RequestDelegate next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await next(context);

            switch (context.Response.StatusCode)
            {
                case (int)HttpStatusCode.Unauthorized:
                    {
                        var httpContext = context.Response.HttpContext;

                        var routeData = httpContext.GetRouteData();
                        var actionContext = new ActionContext(httpContext, routeData, new ActionDescriptor());

                        var data = CustomResponseDto<NoContentDto>.Fail(401, "Giriş yapın.", 3);

                        var result = new ObjectResult(data) { StatusCode = (int)HttpStatusCode.Unauthorized };
                        await result.ExecuteResultAsync(actionContext);
                        break;
                    }

                case (int)HttpStatusCode.Forbidden:
                    {
                        if (context.User.Identity.IsAuthenticated)
                        {

                            var httpContext = context.Response.HttpContext;

                            var routeData = httpContext.GetRouteData();
                            var actionContext = new ActionContext(httpContext, routeData, new ActionDescriptor());

                            var data = CustomResponseDto<NoContentDto>.Fail(403, "Yetkisiz giriş.", 3);

                            var result = new ObjectResult(data) { StatusCode = (int)HttpStatusCode.Forbidden };
                            await result.ExecuteResultAsync(actionContext);
                        }

                        break;
                    }
            }
        }
    }
}
