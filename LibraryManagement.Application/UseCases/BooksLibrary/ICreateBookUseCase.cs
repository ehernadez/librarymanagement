using LibraryManagement.Main.DTOs;

namespace LibraryManagement.Application.UseCases.BooksLibrary
{
    public interface ICreateBookUseCase
    {
        Task<int> CreateAsync(BookCreateDTO bookDto);
    }
}
