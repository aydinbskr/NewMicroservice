namespace NewMicroservice.Payment.Api.Feature.Payments
{
    public record CreatePaymentResponse(Guid? PaymentId, bool Status, string? ErrorMessage);
}
