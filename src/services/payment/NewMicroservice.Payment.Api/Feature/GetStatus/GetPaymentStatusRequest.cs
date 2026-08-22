using NewMicroservice.Shared;

namespace NewMicroservice.Payment.Api.Feature.GetStatus
{
    public record GetPaymentStatusRequest(string orderCode) : IRequestByServiceResult<GetPaymentStatusResponse>;
}
