using LibraryManagement.Main.DTOs;

namespace LibraryManagement.Application.UseCases.BooksLibrary
{
    public interface IUpdateBookUseCase
    {
        Task<bool> UpdateAsync(int id, BookUpdateDTO bookDto);
    }
}
