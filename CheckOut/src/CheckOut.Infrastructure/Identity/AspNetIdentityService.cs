using System;
using System.Linq;
using CheckOut.Application.Abstractions;
using Microsoft.AspNetCore.Http;

namespace CheckOut.Infrastructure.Identity
{
    public class AspNetIdentityService : IUserIdentityService
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        public AspNetIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }

        public string GetTenantId()
        {
            var orgId = this._httpContextAccessor.HttpContext.Request.Headers["x-Org-Id"];

            if (this._httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var tenants = this._httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type.Equals("tenant"));

                if (tenants.Any(x => x.Value.Equals(orgId, StringComparison.OrdinalIgnoreCase)))
                {
                    return orgId;
                }

                return string.Empty;
            }

            return orgId;
        }

        public string GetUserId()
        {
            if (this._httpContextAccessor.HttpContext.User.Identity.IsAuthenticated) {
                return this._httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("sub")).Value;
            }

            return "guest";
            
        }
    }
}
