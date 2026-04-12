using Asp.Versioning.Builder;
using NewMicroservice.Payment.Api.Feature.Payments;
using NewMicroservice.Payment.Api.Feature.GetAllPaymentsByUserId;

namespace NewMicroservice.Payment.Api.Feature
{
    public static class PaymentEndpointExt
    {
        public static void AddPaymentGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/payments").WithTags("payments").WithApiVersionSet(apiVersionSet)
                .CreatePaymentGroupItemEndpoint().GetAllPaymentsByUserIdGroupItemEndpoint();
        }
    }
}
