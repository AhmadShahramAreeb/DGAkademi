namespace LibraryProject.Api.Models
{
    public class BookModel
    {
        public int Id { get; set; }  
        public string Author { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Year { get; set; }
        public string Language { get; set; }
    }
}
