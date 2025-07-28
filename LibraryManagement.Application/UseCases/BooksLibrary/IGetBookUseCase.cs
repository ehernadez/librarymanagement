using LibraryManagement.Main.DTOs;

namespace LibraryManagement.Application.UseCases.BooksLibrary
{
    public interface IGetBookUseCase
    {
        Task<IEnumerable<BookReadDTO>> GetAllAsync();
    }
}
