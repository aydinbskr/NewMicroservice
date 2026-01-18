using NewMicroservice.Catalog.Api.Features.Categories.Dtos;
using NewMicroservice.Catalog.Api.Repositories;
using NewMicroservice.Shared;
using NewMicroservice.Shared.Extensions;
using System.Net;

namespace NewMicroservice.Catalog.Api.Features.Categories.GetById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequest<ServiceResult<CategoryDto>>;

    public class GetCategoryByIdQueryHandler(AppDbContext context)
        : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDto>>
    {
        public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByIdQuery request,
            CancellationToken cancellationToken)
        {
            var category = await context.Categories.FindAsync(request.Id, cancellationToken);

            if (category == null)
                return ServiceResult<CategoryDto>.Error("Category not found",
                    $"The category with id({request.Id}) was not found", HttpStatusCode.NotFound);

            var categoryAsDto = category.Adapt<CategoryDto>();
            return ServiceResult<CategoryDto>.SuccessAsOk(categoryAsDto);
        }
    }

    public static class GetCategoryByIdEndpoint
    {
        public static RouteGroupBuilder GetByIdCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}",
                    async (IMediator mediator, Guid id) =>
                        (await mediator.Send(new GetCategoryByIdQuery(id))).ToGenericResult())
                .MapToApiVersion(1, 0)
                .WithName("GetByIdCategory");


            return group;
        }
    }
}
