using LibraryManagement.Infraestructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Infraestructure.Data
{
    public static class DbInitializer
    {
        public static void Migrate(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
        }
    }
}
