using Asp.Versioning.Builder;
using NewMicroservice.Discount.Api.Features.Discounts.CreateDiscount;
using NewMicroservice.Discount.Api.Features.Discounts.GetDiscountByCode;

namespace NewMicroservice.Discount.Api.Features.Discounts
{
    public static class DiscountEndpointExt
    {
        public static void AddDiscountGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/discounts").WithTags("discounts")
                .WithApiVersionSet(apiVersionSet)
                .CreateDiscountGroupItemEndpoint()
                .GetDiscountByCodeGroupItemEndpoint();
                //.RequireAuthorization();
        }
    }
}
