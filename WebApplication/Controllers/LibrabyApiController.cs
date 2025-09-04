using LibraryManagementSystem.Entities;
using LibraryManagementSystem.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrabyApiController : ControllerBase
    {
        private readonly IBookManager _bookmanager;

        public LibrabyApiController(IBookManager bookManager) {
            _bookmanager=bookManager;
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(Book bookDto)
        {
            await _bookmanager.AddBook(bookDto);
            return Ok("dathem");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var books=await _bookmanager.GetAllBooks();
            return Ok(books);
        }
    }
}
