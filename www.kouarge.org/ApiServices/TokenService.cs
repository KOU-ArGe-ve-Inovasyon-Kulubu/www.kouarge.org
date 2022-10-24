using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using KouArge.Core.Services.ApiService;
using KouArge.Service.Exceptions;
using KouArge.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace www.kouarge.org.ApiServices
{

    public class TokenService : DelegatingHandler
    {
        private readonly IHttpContextAccessor _context;
        //private readonly IAccountApiService _accountApiService;
        private readonly IServiceProvider _provider;



        public TokenService(IHttpContextAccessor context, IServiceProvider provider)
        {
            _context = context;
            _provider = provider;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            var token = _context.HttpContext.Request.Cookies["X-Access-Token"];

            if (!string.IsNullOrEmpty(token) && request.Headers.Authorization is null)
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
            }

            var response = await base.SendAsync(request, cancellationToken);
            //HttpClient _httpClient = new HttpClient();
            //_httpClient.BaseAddress = new Uri("https://localhost:7038/");
            //AccountApiService _accountApiService = new AccountApiService(_httpClient);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {

                var refreshToken = _context.HttpContext.Request.Cookies["Refresh-Token"];

                if(refreshToken!=null)
                {
                    using (var scope = _provider.CreateScope())
                    {
                        var _accountApiService = scope.ServiceProvider.GetRequiredService<IAccountApiService>();
                        var accesToken = _accountApiService.RefreshTokenLogin(new GetRefreshTokenDto() { RefreshToken = refreshToken });

                        if (accesToken != null)
                        {
                            _context.HttpContext.Response.Cookies.Append("X-Access-Token", accesToken.Result.Token.AccessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict, Expires = accesToken.Result.Token.Expiration });
                            _context.HttpContext.Response.Cookies.Append("Refresh-Token", accesToken.Result.Token.RefreshToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict, Expires = accesToken.Result.Token.RefreshTokenExpiration });

                            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", accesToken.Result.Token.AccessToken);

                            response = await base.SendAsync(request, cancellationToken);
                        }
                    }
                  
                }
            }

            return response;
        }
    }
}
