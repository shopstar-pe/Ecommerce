using System;
namespace Vouchers.Application.Abstractions
{
    public interface IUserIdentityService
    {
        string GetUserId();
        string GetTenantId();
    }
}
