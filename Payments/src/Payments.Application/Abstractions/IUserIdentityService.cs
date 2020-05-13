using System;
namespace Payments.Application.Abstractions
{
    public interface IUserIdentityService
    {
        string GetUserId();
        string GetTenantId();
    }
}
