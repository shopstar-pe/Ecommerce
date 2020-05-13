using System;
namespace CheckOut.Application.Abstractions
{
    public interface IUserIdentityService
    {
        string GetUserId();
        string GetTenantId();
    }
}
