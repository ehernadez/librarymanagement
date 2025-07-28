using AutoMapper;
using LibraryManagement.Main.DTOs;
using LibraryManagement.Main.Entities;

namespace LibraryManagement.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Book, BookReadDTO>();
            CreateMap<BookCreateDTO, Book>()
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(_ => DateTime.UtcNow));
            CreateMap<BookUpdateDTO, Book>();
        }
    }
}
