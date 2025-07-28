using LibraryManagement.Application;
using LibraryManagement.Application.Mappings;
using LibraryManagement.Infraestructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Gateway
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddUseCasesServices();
            services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

            return services;
        }
    }
}
