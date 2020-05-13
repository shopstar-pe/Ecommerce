using System;
using System.Threading.Tasks;
using Payments.Application.Abstractions.Models;

namespace Payments.Application.Abstractions
{
    public interface IAuthorizeService
    {
        Task<AuthorizeResponseModel> Authorize(AuthorizeRequestModel request);
    }
}
