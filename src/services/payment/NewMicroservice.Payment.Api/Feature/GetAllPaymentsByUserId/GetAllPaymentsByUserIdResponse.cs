using NewMicroservice.Payment.Api.Repositories;

namespace NewMicroservice.Payment.Api.Feature.GetAllPaymentsByUserId
{
    public record GetAllPaymentsByUserIdResponse(
        Guid Id,
        string OrderCode,
        string Amount,
        DateTime Created,
        PaymentStatus Status);
}
