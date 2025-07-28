using LibraryManagement.Infraestructure.Data;

namespace LibraryManagement.Gateway
{
    public static class DatabaseBootstrapper
    {
        public static void InitializeDatabase(this IServiceProvider services)
        {
            DbInitializer.Migrate(services);
        }
    }
}
