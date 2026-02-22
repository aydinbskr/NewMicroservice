using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewMicroservice.Shared.Extensions;

namespace NewMicroservice.File.Api.Features.File
{
    public static class DeleteFileCommandEndpoint
    {
        public static RouteGroupBuilder DeleteFileGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapDelete("",
                    async ([FromBody] DeleteFileCommand deleteFileCommand, IMediator mediator) =>
                    (await mediator.Send(deleteFileCommand)).ToGenericResult())
                .WithName("delete")
                .MapToApiVersion(1, 0)
                .Produces<Guid>(StatusCodes.Status201Created)
                .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return group;
        }
    }
}
