using LibraryManagement.API.Responses;
using LibraryManagement.Application.UseCases.BooksLibrary;
using LibraryManagement.Main.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Endpoints
{
    public static class BookEndpoints
    {
        public static void MapBookEndpoints(this WebApplication app)
        {
            app.MapPost("/books", async (BookCreateDTO bookDto, [FromServices] ICreateBookUseCase service) =>
            {
                var id = await service.CreateAsync(bookDto);

                return Results.Created(
                    $"/books/{id}",
                    ApiResponse<int>.Ok(id, "Libro creado correctamente")
                );
            })
            .WithName("CreateBook")
            .WithOpenApi();

            app.MapGet("/books", async ([FromServices] IGetBookUseCase service) =>
            {
                var books = await service.GetAllAsync();
                return Results.Ok(ApiResponse<IEnumerable<BookReadDTO>>.Ok(books));
            })
            .WithName("GetAllBooks")
            .WithOpenApi();

            app.MapGet("/books/{id:int}", async (int id, [FromServices] IGetBookByIdUseCase service) =>
            {
                var book = await service.GetByIdAsync(id);
                return Results.Ok(ApiResponse<BookReadDTO>.Ok(book));
            })
            .WithName("GetBookById")
            .WithOpenApi();

            app.MapPut("/books/{id:int}", async (int id, BookUpdateDTO bookDto, [FromServices] IUpdateBookUseCase service) =>
            {
                await service.UpdateAsync(id, bookDto);
                return Results.Ok(ApiResponse<string>.Ok("Libro actualizado correctamente"));
            })
            .WithName("UpdateBook")
            .WithOpenApi();

            app.MapDelete("/books/{id:int}", async (int id, [FromServices] IDeleteBookUseCase service) =>
            {
                await service.DeleteAsync(id);
                return Results.Ok(ApiResponse<string>.Ok("Libro eliminado correctamente"));
            })
            .WithName("DeleteBook")
            .WithOpenApi();
        }
    }
}
