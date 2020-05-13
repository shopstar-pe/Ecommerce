using System;
using System.Threading.Tasks;
using Payments.Application.Abstractions;
using Payments.Application.Abstractions.Models;

namespace Payments.Integration.VisaNet
{
    public class RefundService : IRefundService
    {
        public Task<RefundResponseModel> Authorize(RefundRequestModel request)
        {
            throw new NotImplementedException();
        }
    }
}
