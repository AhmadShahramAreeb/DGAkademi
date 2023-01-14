using Microsoft.EntityFrameworkCore;
using LibraryProject.Api.Models;


namespace LibraryProject.Api.Data
{
    public class BookLibContext : DbContext
    {
        public BookLibContext(DbContextOptions<BookLibContext> options) : base(options)
        {

        }

        //this command creates Books class table in database
        public DbSet<Books> Books { get; set; }
    }
}
