using AutoMapper;
using LibraryManagement.Main.DTOs;
using LibraryManagement.Main.Interfaces;

namespace LibraryManagement.Application.UseCases.BooksLibrary.Implementation
{
    internal class GetBookUseCase(IBookRepository bookRepository, IMapper mapper) : IGetBookUseCase
    {
        public async Task<IEnumerable<BookReadDTO>> GetAllAsync()
        {
            var books = await bookRepository.GetAllAsync();
            return mapper.Map<IEnumerable<BookReadDTO>>(books);
        }
    }
}
