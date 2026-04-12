using MediatR;
using NewMicroservice.Order.Application.Contracts.Repositories;
using NewMicroservice.Order.Application.Contracts.UnitOfWork;
using NewMicroservice.Order.Domain.Entities;
using NewMicroservice.Shared;
using NewMicroservice.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewMicroservice.Order.Application.Features.Orders.Create
{
    public class CreateOrderCommandHandler(
    IOrderRepository orderRepository,
    IGenericRepository<int, Address> addressRepository,
    IIdentityService identityService,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, ServiceResult>
    {
        public async Task<ServiceResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            if (!request.Items.Any())
                return ServiceResult.Error("Order items not found", "Order must have at least one item",
                    HttpStatusCode.BadRequest);


            var newAddress = new Address
            {
                Province = request.Address.Province,
                District = request.Address.District,
                Street = request.Address.Street,
                ZipCode = request.Address.ZipCode,
                Line = request.Address.Line
            };


            var order = Domain.Entities.Order.CreateUnPaidOrder(identityService.GetUserId, request.DiscountRate,
                newAddress.Id);
            foreach (var orderItem in request.Items)
                order.AddOrderItem(orderItem.ProductId, orderItem.ProductName, orderItem.UnitPrice);


            order.Address = newAddress;


            orderRepository.Add(order);
            await unitOfWork.CommitAsync(cancellationToken);


            //var paymentRequest = new CreatePaymentRequest(order.Code, request.Payment.CardNumber,
            //    request.Payment.CardHolderName, request.Payment.Expiration, request.Payment.Cvc, order.TotalPrice);
            //var paymentResponse = await paymentService.CreateAsync(paymentRequest);


            //if (!paymentResponse.Status)
            //    return ServiceResult.Error(paymentResponse.ErrorMessage!, HttpStatusCode.InternalServerError);


            //order.SetPaidStatus(paymentResponse.PaymentId!.Value);

            orderRepository.Update(order);
            await unitOfWork.CommitAsync(cancellationToken);


            //await publishEndpoint.Publish(new OrderCreatedEvent(order.Id, identityService.GetUserId),
            //    cancellationToken);
            return ServiceResult.SuccessAsNoContent();
        }
    }
}
