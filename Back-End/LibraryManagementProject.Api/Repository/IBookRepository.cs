using LibraryProject.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryProject.Api.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByProp(int bookId, BookModel bookModel);
        Task<int> AddBookAsync(BookModel bookModel);
        Task UpdataBookAsync(int bookId, BookModel bookModel);
        Task UpdateBookByPatch(int bookId, JsonPatchDocument bookModel);
        Task DeleteBookAsync(int bookId);
    }
}