namespace NewMicroservice.Payment.Api.Feature.GetStatus
{
    public record GetPaymentStatusResponse(Guid? PaymentId, bool IsPaid);
}
