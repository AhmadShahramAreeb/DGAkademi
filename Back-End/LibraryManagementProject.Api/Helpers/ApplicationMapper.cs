using AutoMapper;
using LibraryProject.Api.Data;
using LibraryProject.Api.Models;

namespace LibraryProject.Api.Helpers
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
            // Books=>BookModel yapiyor ,reverse ile tersi yapiliyor
        }
    }
}
