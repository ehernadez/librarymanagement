using LibraryManagement.Application.UseCases.BooksLibrary;
using LibraryManagement.Application.UseCases.BooksLibrary.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services) 
        {
            services.AddTransient<ICreateBookUseCase, CreateBookUseCase>();
            services.AddTransient<IGetBookUseCase, GetBookUseCase>();
            services.AddTransient<IGetBookByIdUseCase, GetBookByIdUseCase>();
            services.AddTransient<IUpdateBookUseCase, UpdateBookUseCase>();
            services.AddTransient<IDeleteBookUseCase, DeleteBookUseCase>();

            return services;
        }
    }
}
