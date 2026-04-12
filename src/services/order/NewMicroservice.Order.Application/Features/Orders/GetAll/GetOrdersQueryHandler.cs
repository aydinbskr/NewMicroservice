using Mapster;
using MapsterMapper;
using MediatR;
using NewMicroservice.Order.Application.Contracts.Repositories;
using NewMicroservice.Order.Application.Features.Orders.Create;
using NewMicroservice.Shared;
using NewMicroservice.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMicroservice.Order.Application.Features.Orders.GetAll
{
    public class GetOrdersQueryHandler(IIdentityService identityService, IOrderRepository orderRepository) : IRequestHandler<GetOrdersQuery, ServiceResult<List<GetOrdersResponse>>>
    {
        public async Task<ServiceResult<List<GetOrdersResponse>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await orderRepository.GetOrderByBuyerId(identityService.GetUserId);


            var response = orders.Select(o => new GetOrdersResponse(o.Created, o.TotalPrice, o.OrderItems.Adapt<List<OrderItemDto>>())).ToList();


            return ServiceResult<List<GetOrdersResponse>>.SuccessAsOk(response);
        }
    }
}
