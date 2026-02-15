using Asp.Versioning.Builder;
using NewMicroservice.Basket.Api.Features.Baskets.AddBasketItem;
using NewMicroservice.Basket.Api.Features.Baskets.ApplyDiscountCoupon;
using NewMicroservice.Basket.Api.Features.Baskets.DeleteBasketItem;
using NewMicroservice.Basket.Api.Features.Baskets.GetBasket;
using NewMicroservice.Basket.Api.Features.Baskets.RemoveDiscountCoupon;

namespace NewMicroservice.Basket.Api.Features
{
    public static class BasketEndpointExt
    {
        public static void AddBasketGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{version:apiVersion}/baskets").WithTags("Baskets")
                .WithApiVersionSet(apiVersionSet)
                .AddBasketItemGroupItemEndpoint()
                .DeleteBasketItemGroupItemEndpoint()
                .GetBasketGroupItemEndpoint()
                .ApplyDiscountCouponGroupItemEndpoint()
                .RemoveDiscountCouponGroupItemEndpoint();
        }
    }
}
