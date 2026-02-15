using Mapster;
using MapsterMapper;
using MediatR;
using NewMicroservice.Basket.Api.Dto;
using NewMicroservice.Shared;
using System.Net;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NewMicroservice.Basket.Api.Features.Baskets.GetBasket
{
    public class GetBasketQueryHandler(
    BasketService basketService)
    : IRequestHandler<GetBasketQuery, ServiceResult<BasketDto>>
    {
        public async Task<ServiceResult<BasketDto>> Handle(GetBasketQuery request,
            CancellationToken cancellationToken)
        {
            var basketAsString = await basketService.GetBasketFromCache(cancellationToken);

            if (string.IsNullOrEmpty(basketAsString))
                return ServiceResult<BasketDto>.Error("Basket not found", HttpStatusCode.NotFound);

            var basket = JsonSerializer.Deserialize<Data.Basket>(basketAsString)!;

            var basketDto = basket.Adapt<BasketDto>();


            return ServiceResult<BasketDto>.SuccessAsOk(basketDto);
        }
    }
}
