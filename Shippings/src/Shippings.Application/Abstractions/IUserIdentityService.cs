using System;
namespace Shippings.Application.Abstractions
{
    public interface IUserIdentityService
    {
        string GetUserId();
        string GetTenantId();
    }
}
