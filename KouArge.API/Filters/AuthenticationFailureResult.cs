//using KouArge.Core.DTOs;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Authorization.Policy;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Authorization;
//using Microsoft.AspNetCore.Mvc.Filters;

//public class CustomAuthorizationFilter : IAsyncAuthorizationFilter
//{
//    public AuthorizationPolicy Policy { get; }

//    public CustomAuthorizationFilter()
//    {
//        Policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
//    }

//    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
//    {
//        if (context == null)
//        {
//            throw new ArgumentNullException(nameof(context));
//        }

//        // Allow Anonymous skips all authorization
//        if (context.Filters.Any(item => item is IAllowAnonymousFilter))
//        {
//            return;
//        }

//        var policyEvaluator = context.HttpContext.RequestServices.GetRequiredService<IPolicyEvaluator>();
//        var authenticateResult = await policyEvaluator.AuthenticateAsync(Policy, context.HttpContext);
//        var authorizeResult = await policyEvaluator.AuthorizeAsync(Policy, authenticateResult, context.HttpContext, context);

//        if (authorizeResult.Forbidden)
//        {
//            var data = CustomResponseDto<NoContentDto>.Fail(401, "Yetkisiz giriş.", 3);
//            // Return custom 401 result
//            context.Result = new JsonResult(new
//            {
//                data
//            })
//            {
//                StatusCode = StatusCodes.Status401Unauthorized
//            };
//        }
//    }
//}