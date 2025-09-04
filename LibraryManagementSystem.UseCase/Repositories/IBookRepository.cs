using LibraryManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.UseCase.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(Guid id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book, List<Guid> authorIds);
        Task DeleteAsync(Guid id);
    }
}
