namespace LibraryManagement.Application.UseCases.BooksLibrary
{
    public interface IDeleteBookUseCase
    {
        Task<bool> DeleteAsync(int id);
    }
}
