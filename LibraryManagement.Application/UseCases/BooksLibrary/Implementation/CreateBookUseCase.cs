using LibraryManagement.Main.DTOs;
using LibraryManagement.Main.Entities;
using LibraryManagement.Main.Extensions;
using LibraryManagement.Main.Interfaces;
using AutoMapper;

namespace LibraryManagement.Application.UseCases.BooksLibrary.Implementation
{

internal class CreateBookUseCase(IBookRepository bookRepository, IMapper mapper) : ICreateBookUseCase
    {
        public async Task<int> CreateAsync(BookCreateDTO bookDto)
        {
            bookDto.Title.ValidateValue(nameof(bookDto.Title));
            bookDto.Author.ValidateValue(nameof(bookDto.Author));

            var createBook = mapper.Map<Book>(bookDto);
            await bookRepository.AddAsync(createBook);

            return createBook.Id;
        }
    }
}
