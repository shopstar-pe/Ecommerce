using System;
namespace Sales.Application.Abstractions
{
    public interface IUserIdentityService
    {
        string GetUserId();
        string GetTenantId();
    }
}
