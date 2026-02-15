using NewMicroservice.Basket.Api.Dto;
using NewMicroservice.Shared;

namespace NewMicroservice.Basket.Api.Features.Baskets.GetBasket
{
    
    public record GetBasketQuery : IRequestByServiceResult<BasketDto>;
}
