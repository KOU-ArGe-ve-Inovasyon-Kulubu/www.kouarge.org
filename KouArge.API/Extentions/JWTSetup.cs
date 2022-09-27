using KouArge.Core.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KouArge.API.Extentions
{
    public static class JWTSetup
    {
        public static void RegisterJWT(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(x =>
           {
               x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
               x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
           {
               options.TokenValidationParameters = new()
               {

                   ValidateAudience = true,//oluşturulacak tokenların hangi sitelerin kullanabilceğini kontrol eder. www.asd.com
                   ValidateIssuer = false,//token degerini kimin dagıttınıgı ifade decegimiz alan.   api.com
                   ValidateLifetime = true,//oluşturulan token değerinini süresinini kontrol edecek değer
                   ValidateIssuerSigningKey = true,//oluşuturlacak token degerinin uygulamamıza ait olup olmadığını kontrol eden değer

                   ValidAudience = builder.Configuration["Token:Audience"],
                   ValidIssuer = builder.Configuration["Token:Issuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
                   LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false
               };
               //options.Events = new JwtBearerEvents
               //{
               //    OnForbidden = async context =>
               //    {
               //        var httpContext = context.HttpContext;
               //        var statusCode = StatusCodes.Status403Forbidden;

               //        var routeData = httpContext.GetRouteData();
               //        var actionContext = new ActionContext(httpContext, routeData, new ActionDescriptor());

               //        var factory = httpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
               //        var problemDetails = factory.CreateProblemDetails(httpContext, statusCode);

               //        var data = CustomResponseDto<NoContentDto>.Fail(403, "Yetkisiz giriş.", 3);

               //        var result = new ObjectResult(data) { StatusCode = statusCode };
               //        await result.ExecuteResultAsync(actionContext);
               //    },
               //    OnChallenge = async context =>
               //    {
               //        context.HandleResponse();

               //        var httpContext = context.HttpContext;
               //        var statusCode = StatusCodes.Status401Unauthorized;

               //        var routeData = httpContext.GetRouteData();
               //        var actionContext = new ActionContext(httpContext, routeData, new ActionDescriptor());

               //        var factory = httpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
               //        var problemDetails = factory.CreateProblemDetails(httpContext, statusCode);

               //        var data = CustomResponseDto<NoContentDto>.Fail(401, "Giriş yapın.", 3);

               //        var result = new ObjectResult(data) { StatusCode = statusCode };
               //        await result.ExecuteResultAsync(actionContext);
               //    }
               //};
           });

        }
    }
}
