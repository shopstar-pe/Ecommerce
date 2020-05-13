using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Vouchers.Application.Abstractions;

namespace Vouchers.Infrastructure.Identity
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
            var tenants = this._httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type.Equals("tenant"));

            var orgId = this._httpContextAccessor.HttpContext.Request.Headers["x-Org-Id"];

            if (tenants.Any(x => x.Value.Equals(orgId, StringComparison.OrdinalIgnoreCase)))
            {
                return orgId;
            }

            return string.Empty;
        }

        public string GetUserId()
        {
            return this._httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type.Equals("sub")).Value;
        }
    }
}
