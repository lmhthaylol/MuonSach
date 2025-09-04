using LibraryManagementSystem.Entities;

namespace LibraryManagementSystem.UseCase
{
    public interface IBookManager
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(Guid bookId);
        Task AddBook(Book book);
        Task UpdateBook(Guid bookId, Book book);
        Task DeleteBook(Guid bookId);
    }
}
