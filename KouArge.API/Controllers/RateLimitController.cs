using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data;

namespace KouArge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

    public class RateLimitController : ControllerBase
    {
        private readonly IpRateLimitOptions _options;
        private readonly IIpPolicyStore _policyStore;

        public RateLimitController(IOptions<IpRateLimitOptions> options, IIpPolicyStore policyStore)
        {
            _options = options.Value;
            _policyStore = policyStore;
        }

        [HttpGet]
        public async Task<IpRateLimitPolicies> GetIpRateLimitPolicies()
        {
            // Return IP Rate Limit Policies
            IpRateLimitPolicies? policies = await _policyStore.GetAsync(_options.IpPolicyPrefix);
            return policies;
        }

        [HttpPost]
        public async Task AddIpRateLimitPolicies(int limit1, int limit2, int limit3, int second, int minute, int hour)
        {
            // Get the policies
            IpRateLimitPolicies? policies = await _policyStore.GetAsync(_options.IpPolicyPrefix);

            if (policies != null)
            {
                // Add a new Ip Rule at runtime
                policies.IpRules.Add(new IpRateLimitPolicy
                {
                    Rules = new List<RateLimitRule>(new RateLimitRule[]
                    {
                        new RateLimitRule
                        {
                            Endpoint = "*",
                            Limit = limit1,
                            Period = $"{second}s"
                        },
                        new RateLimitRule
                        {
                            Endpoint = "*",
                            Limit = limit2,
                            Period = $"{minute}m"
                        },
                        new RateLimitRule
                        {
                            Endpoint = "*",
                            Limit = limit3,
                            Period = $"{hour}h"
                        }
                    })
                });

                // Set the new policy
                await _policyStore.SetAsync(_options.IpPolicyPrefix, policies);
            }
        }
    }
}
