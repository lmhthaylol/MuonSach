using LibraryManagementSystem.Entities;
using LibraryManagementSystem.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/LibApi")]
    [ApiController]
    public class LibApiController : ControllerBase
    {
        private readonly IBookManager _bookManager;

        public LibApiController(IBookManager bookManager) {
            _bookManager=bookManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBook()
        {
            var books= await _bookManager.GetAllBooks();
            return Ok("ok");
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            await _bookManager.AddBook(book);
            return Ok("dathem");
        }
    }
}
