using LibraryManagement.Main.DTOs;
using LibraryManagement.Main.Entities;
using LibraryManagement.Main.Interfaces;
using LibraryManagement.Main.Exceptions;
using AutoMapper;

namespace LibraryManagement.Application.UseCases.BooksLibrary.Implementation
{
    internal class GetBookByIdUseCase(IBookRepository bookRepository, IMapper mapper) : IGetBookByIdUseCase
    {
        public async Task<BookReadDTO> GetByIdAsync(int id)
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new NotFoundException($"El libro con id {id} no fue encontrado.");
            return mapper.Map<BookReadDTO>(book);
        }
    }
}
