using AutoMapper;
using WebApiProject.Coomon;
using WebApiProject.Entities;
using static WebApiProject.BookOperations.CreateBookCommand;
using static WebApiProject.BookOperations.GetBooksQuery;
using static WebApiProject.BookOperations.GetByIdQuery;

namespace WebApiProject.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() //ne neye dönüşebilir config
        {
            CreateMap<CreateBookModel, Book>();  //source-target, createbookmodel objesi book objesine maplenebilsin
            CreateMap<Book, BookGetByIdViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString())); //booksviewmodel içerisindeki genre'yı belirtilen şekilde maplemek için mapfrom ile nereden mapleneceği belirtilir
            CreateMap<Book,BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
