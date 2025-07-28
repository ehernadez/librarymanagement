using LibraryManagement.Main.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infraestructure.DataContext
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books => Set<Book>();
    }
}
