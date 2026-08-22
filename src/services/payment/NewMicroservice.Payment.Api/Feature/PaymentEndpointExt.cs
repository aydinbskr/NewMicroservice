using Asp.Versioning.Builder;
using NewMicroservice.Payment.Api.Feature.GetAllPaymentsByUserId;
using NewMicroservice.Payment.Api.Feature.GetStatus;
using NewMicroservice.Payment.Api.Feature.Payments;

namespace NewMicroservice.Payment.Api.Feature
{
    public static class PaymentEndpointExt
    {
        public static void AddPaymentGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/payments").WithTags("payments").WithApiVersionSet(apiVersionSet)
                .CreatePaymentGroupItemEndpoint()
                .GetAllPaymentsByUserIdGroupItemEndpoint()
                .GetPaymentStatusGroupItemEndpoint();
        }
    }
}
