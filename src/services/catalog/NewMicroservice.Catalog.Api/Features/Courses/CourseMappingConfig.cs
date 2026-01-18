using NewMicroservice.Catalog.Api.Features.Categories;

namespace NewMicroservice.Catalog.Api.Features.Courses
{
    public class CourseMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Course, Dtos.CourseDto>()
                  .Map(dest => dest.Name, src => src.Name.ToUpper());
        }
    }
}
