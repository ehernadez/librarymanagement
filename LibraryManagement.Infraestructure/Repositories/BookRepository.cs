using LibraryManagement.Infraestructure.DataContext;
using LibraryManagement.Main.Entities;
using LibraryManagement.Main.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infraestructure.Repositories
{
    internal class BookRepository(AppDbContext context) : IBookRepository
    {
        public async Task AddAsync(Book book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Book book)
        {
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync() => await context.Books.OrderDescending().ToListAsync();

        public async Task<Book?> GetByIdAsync(int id) => await context.Books.FindAsync(id);

        public async Task UpdateAsync(Book book)
        {
            context.Books.Update(book);
            await context.SaveChangesAsync();
        }
    }
}
