using System;
using System.Threading.Tasks;
using Payments.Application.Abstractions.Models;

namespace Payments.Application.Abstractions
{
    public interface ICancelService
    {
        Task<CancelResponseModel> Cancel(CancelRequestModel request);
    }
}
