
using LibraryProject.Api.Models;
using LibraryProject.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryProject.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
       

        public BooksController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
            
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books=await this.bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookByProp([FromRoute]int id, [FromBody]BookModel bookModel)
        {
            var book = await this.bookRepository.GetBookByProp(id, bookModel);

            return Ok(book);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddBook([FromBody] BookModel bookModel)
        {
            var id = await this.bookRepository.AddBookAsync( bookModel);
            

            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute]int id, [FromBody]BookModel bookModel)
        {
            this.bookRepository.UpdataBookAsync(id, bookModel);

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] JsonPatchDocument bookModel, [FromRoute] int id)
        {
          await this.bookRepository.UpdateBookByPatch(id, bookModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await this.bookRepository.DeleteBookAsync(id);

            return Ok();
        }

    }
}
