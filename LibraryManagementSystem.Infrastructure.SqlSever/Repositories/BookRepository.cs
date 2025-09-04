using AutoMapper;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.Infrastructure.SqlSever.Data;
using LibraryManagementSystem.UseCase.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem.Infrastructure.SqlSever.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;
        private readonly IMapper _mapper;

        public BookRepository(LibraryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var books = await _dbContext.Books.ToListAsync();
            return _mapper.Map<IEnumerable<Book>>(books);
        }
        public async Task<Book> GetByIdAsync(Guid id)
        {
            var book = await _dbContext.Books.SingleOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<Book>(book);
        }
        public async Task AddAsync(Book book)
        {
            var bookModel = _mapper.Map<BookModel>(book);

            await _dbContext.Books.AddAsync(bookModel);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Book book, List<Guid> authorIds)
        {
            var existingBookModel = await _dbContext.Books
                   .Include(b => b.BookAuthors) // Bao gồm các tác giả hiện có để xử lý mối quan hệ
                   .FirstOrDefaultAsync(b => b.Id == book.Id);

            if (existingBookModel == null)
            {
                return;
            }

            // Ánh xạ các thuộc tính từ Book sang BookModel
            _mapper.Map(book, existingBookModel);

            // Xóa tất cả các tác giả cũ của cuốn sách này
            _dbContext.BookAuthors.RemoveRange(existingBookModel.BookAuthors);

            // Thêm các tác giả mới dựa trên danh sách authorIds đã truyền vào
            foreach (var authorId in authorIds)
            {
                var newBookAuthor = new BookAuthorModel
                {
                    BookId = existingBookModel.Id,
                    AuthorId = authorId
                };
                await _dbContext.BookAuthors.AddAsync(newBookAuthor);
            }

            // Lưu tất cả thay đổi vào database
            await _dbContext.SaveChangesAsync();

        }
        public async Task DeleteAsync(Guid id)
        {
            var bookToDelete = await _dbContext.Books.FindAsync(id);

            // Nếu tìm thấy, thực hiện xóa
            if (bookToDelete != null)
            {
                _dbContext.Books.Remove(bookToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

    }
}
