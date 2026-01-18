using Mapster;

namespace NewMicroservice.Catalog.Api.Features.Categories
{
    public class CategoryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Category, Dtos.CategoryDto>()
                  .Map(dest => dest.Name, src => src.Name.ToUpper());
        }
    }
}
