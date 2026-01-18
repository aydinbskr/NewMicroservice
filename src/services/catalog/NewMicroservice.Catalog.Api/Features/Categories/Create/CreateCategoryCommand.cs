using MediatR;
using NewMicroservice.Shared;

namespace NewMicroservice.Catalog.Api.Features.Categories.Create
{
    public record CreateCategoryCommand(string Name, string Description) : IRequest<ServiceResult<CreateCategoryResponse>>;
}
