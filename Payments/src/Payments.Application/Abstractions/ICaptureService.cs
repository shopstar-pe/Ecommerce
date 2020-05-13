using System;
using System.Threading.Tasks;
using Payments.Application.Abstractions.Models;

namespace Payments.Application.Abstractions
{
    public interface ICaptureService
    {
        Task<CaptureResponseModel> Capture(CaptureRequestModel request);
    }
}
