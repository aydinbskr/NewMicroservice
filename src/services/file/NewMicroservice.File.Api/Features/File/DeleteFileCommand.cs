using NewMicroservice.Shared;

namespace NewMicroservice.File.Api.Features.File
{
    public record DeleteFileCommand(string FileName) : IRequestByServiceResult;
}
