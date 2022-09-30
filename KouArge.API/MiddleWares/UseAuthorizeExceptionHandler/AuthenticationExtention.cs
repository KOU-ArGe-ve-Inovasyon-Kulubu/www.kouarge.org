namespace KouArge.API.MiddleWares.UseAuthorizeExceptionHandler
{
    public static class AuthenticationExtention
    {
        public static IApplicationBuilder UseAuthenticationExtention(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
