using LibraryManagement.Main.Entities;
using LibraryManagement.Main.Interfaces;
using LibraryManagement.Main.Exceptions;
namespace LibraryManagement.Application.UseCases.BooksLibrary.Implementation
{
    internal class DeleteBookUseCase(IBookRepository bookRepository) : IDeleteBookUseCase
    {
        public async Task<bool> DeleteAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new NotFoundException($"el Libro con id {id} no fue encontrado.");
            await bookRepository.DeleteAsync(book);
            return true;
        }
    }
}
