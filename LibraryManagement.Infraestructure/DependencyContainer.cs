using LibraryManagement.Infraestructure.DataContext;
using LibraryManagement.Infraestructure.Repositories;
using LibraryManagement.Main.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Infraestructure
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<AppDbContext>(opt =>
                opt.UseNpgsql(connectionString));

            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
