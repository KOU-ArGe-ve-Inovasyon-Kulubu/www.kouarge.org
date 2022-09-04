namespace www.kouarge.org.ApiServices
{
    public class TokenService : DelegatingHandler
    {
        private IHttpContextAccessor _context;
        public TokenService(IHttpContextAccessor context)
        {
            _context = context;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _context.HttpContext.Request.Cookies["X-Access-Token"];
            if (!string.IsNullOrEmpty(token) && request.Headers.Authorization is null)
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
