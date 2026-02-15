using FluentValidation;
using FluentValidation.AspNetCore;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using NewMicroservice.Shared.Services;
using System.Reflection;

namespace NewMicroservice.Shared.Extensions
{
    public static class CommonServiceExt
    {
        public static IServiceCollection AddCommonServiceExt(this IServiceCollection services, Type assembly)
        {
            services.AddHttpContextAccessor();
            services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(assembly));

            services.AddFluentValidation();
            services.AddValidatorsFromAssemblyContaining(assembly);
            services.AddScoped<IIdentityService, IdentityServiceFake>();

           
            TypeAdapterConfig.GlobalSettings.Scan(assembly.Assembly);
            //services.AddAutoMapper(assembly);
            //services.AddExceptionHandler<GlobalExceptionHandler>();
            return services;
        }
    }
}
