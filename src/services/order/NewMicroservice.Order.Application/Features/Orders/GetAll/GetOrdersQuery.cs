using NewMicroservice.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMicroservice.Order.Application.Features.Orders.GetAll
{
    public record GetOrdersQuery : IRequestByServiceResult<List<GetOrdersResponse>>;
}
