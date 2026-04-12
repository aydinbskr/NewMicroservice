using NewMicroservice.Shared;

namespace NewMicroservice.Payment.Api.Feature.GetAllPaymentsByUserId
{
    public record GetAllPaymentsByUserIdQuery : IRequestByServiceResult<List<GetAllPaymentsByUserIdResponse>>;
}
