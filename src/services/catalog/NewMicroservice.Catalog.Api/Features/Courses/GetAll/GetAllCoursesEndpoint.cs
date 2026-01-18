using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using NewMicroservice.Catalog.Api.Features.Courses.Dtos;
using NewMicroservice.Catalog.Api.Repositories;
using NewMicroservice.Shared;

namespace NewMicroservice.Catalog.Api.Features.Courses.GetAll
{
    public record GetAllCoursesQuery() : IRequestByServiceResult<List<CourseDto>>;


    public class GetAllCoursesQueryHandler(AppDbContext context)
        : IRequestHandler<GetAllCoursesQuery, ServiceResult<List<CourseDto>>>
    {
        public async Task<ServiceResult<List<CourseDto>>> Handle(GetAllCoursesQuery request,
            CancellationToken cancellationToken)
        {
            var courses = await context.Courses
                .ToListAsync(cancellationToken: cancellationToken);

            var categories = await context.Categories.ToListAsync(cancellationToken: cancellationToken);


            foreach (var course in courses)
            {
                course.Category = categories.First(x => x.Id == course.CategoryId);
            }

            var coursesAsDto = courses.Adapt<List<CourseDto>>();
            return ServiceResult<List<CourseDto>>.SuccessAsOk(coursesAsDto);
        }
    }


    public static class GetAllCoursesEndpoint
    {
        public static RouteGroupBuilder GetAllCourseGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/",
                    async (IMediator mediator) =>
                        (await mediator.Send(new GetAllCoursesQuery())).ToGenericResult())
                .WithName("GetAllCourses");

            return group;
        }
    }
}
