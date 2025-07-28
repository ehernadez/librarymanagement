using LibraryManagement.Main.DTOs;

namespace LibraryManagement.Application.UseCases.BooksLibrary
{
    public interface IGetBookByIdUseCase
    {
        Task<BookReadDTO> GetByIdAsync(int id);
    }
}
