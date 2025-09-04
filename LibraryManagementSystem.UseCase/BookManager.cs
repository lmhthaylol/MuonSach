using AutoMapper;
using LibraryManagementSystem.Entities;
using LibraryManagementSystem.UseCase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.UseCase
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookManager(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task AddBook(Book book)
        {
            await _bookRepository.AddAsync(book);
        }

        public Task DeleteBook(Guid bookId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllAsync();
        }

        public Task<Book> GetBookById(Guid bookId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBook(Guid bookId, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
