using System;
using System.Threading.Tasks;
using Payments.Application.Abstractions.Models;

namespace Payments.Application.Abstractions
{
    public interface IRefundService
    {
        Task<RefundResponseModel> Authorize(RefundRequestModel request);
    }
}
