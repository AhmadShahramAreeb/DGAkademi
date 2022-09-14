using AutoMapper;
using LibraryProject.Api.Data;
using LibraryProject.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Api.Repository
{
    public class BookRepository:IBookRepository
    {
        private readonly BookLibContext context;
        private readonly IMapper mapper;

        public BookRepository(BookLibContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var records = await this.context.Books.ToListAsync();

            return this.mapper.Map<List<BookModel>>(records);
        }

        public async Task<BookModel> GetBookByProp(int bookId,BookModel bookModel)
        {
            
            var book = await this.context.Books.Where(x=>
            x.Author==bookModel.Author||x.Subject==bookModel.Subject||x.Title==bookModel.Title)
                .Select(x=>new BookModel()
                {
                    Author=x.Author,
                    Subject=x.Subject,
                    Title=x.Title,
                    Id=x.Id,
                    Year=x.Year,
                    Language=x.Language
                }).FirstOrDefaultAsync();

            return book;
        }
        
        public async Task<int>  AddBookAsync(BookModel bookModel)
        {
            var record = this.mapper.Map<Books>(bookModel);
            this.context.Books.Add(record);
            await this.context.SaveChangesAsync();
            return record.Id;
        }

        public async Task UpdataBookAsync(int bookId, BookModel bookModel)
        {
            //we hit the database 2 times this efects performance
            /* var book = await this.context.Books.FindAsync(bookId);
             if (book!=null)
             {                                     
                book.Title = bookModel.Title;
                book.Description = bookModel.Description;
                await this.context.SaveChangesAsync();
             }*/

            //in the following code we hit the database single time
            var book= this.mapper.Map<Books>(bookModel);
            book.Id=bookId;

            this.context.Update(book);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateBookByPatch(int bookId, JsonPatchDocument bookModel)
        {
            var book = await this.context.Books.FindAsync(bookId);
            if (book!=null)
            {
                bookModel.ApplyTo(book);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task DeleteBookAsync(int bookId)
        {
            //This commands is useful when we dont have the primary key
            /*var book = this.context.Books.Where(x => x.Title == "").FirstOrDefault();*/


            //if we have the primary key
            var book = new Books() { Id = bookId };

            this.context.Books.Remove(book);
            await this.context.SaveChangesAsync();
        }
    }
}
