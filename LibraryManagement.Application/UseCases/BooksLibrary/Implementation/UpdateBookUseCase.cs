using AutoMapper;
using LibraryManagement.Main.DTOs;
using LibraryManagement.Main.Exceptions;
using LibraryManagement.Main.Extensions;
using LibraryManagement.Main.Interfaces;

namespace LibraryManagement.Application.UseCases.BooksLibrary.Implementation
{
    internal class UpdateBookUseCase(IBookRepository bookRepository, IMapper mapper) : IUpdateBookUseCase
    {
        public async Task<bool> UpdateAsync(int id, BookUpdateDTO bookDto)
        {
            bookDto.Title.ValidateValue(nameof(bookDto.Title));
            bookDto.Author.ValidateValue(nameof(bookDto.Author));
            
            var book = await bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new NotFoundException($"El libro con id {id} no fue encontrado.");
            mapper.Map(bookDto, book);
            await bookRepository.UpdateAsync(book);
            return true;
        }
    }
}
