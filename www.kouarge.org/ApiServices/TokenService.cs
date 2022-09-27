using KouArge.Core.DTOs;
using KouArge.Core.Services;
using KouArge.Service.Exceptions;
using KouArge.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace www.kouarge.org.ApiServices
{
    public static class Control
    {
        public static int c = 0;
    }
    public class TokenService : DelegatingHandler
    {
        private IHttpContextAccessor _context;
        public TokenService(IHttpContextAccessor context)
        {
            _context = context;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _context.HttpContext.Request.Cookies["X-Access-Token"];

            if (!string.IsNullOrEmpty(token) && request.Headers.Authorization is null)
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
            }
           
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
