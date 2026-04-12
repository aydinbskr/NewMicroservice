using NewMicroservice.Shared;

namespace NewMicroservice.Payment.Api.Feature.Payments
{
    public record CreatePaymentCommand(
        string OrderCode,
        string CardNumber,
        string CardHolderName,
        string CardExpirationDate,
        string CardSecurityNumber,
        decimal Amount) : IRequestByServiceResult<Guid>;
}
