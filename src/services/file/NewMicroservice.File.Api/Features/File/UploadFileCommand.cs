using NewMicroservice.Shared;

namespace NewMicroservice.File.Api.Features.File
{
    public record UploadFileCommand(IFormFile File) : IRequestByServiceResult<UploadFileCommandResponse>;
}
