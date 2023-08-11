using AutoMapper;
using WebApiProject.Coomon;
using WebApiProject.Entities;
using static WebApiProject.Services.BookOperations.CreateBookCommand;
using static WebApiProject.Services.BookOperations.GetBooksQuery;
using static WebApiProject.Services.BookOperations.GetByIdQuery;
using static WebApiProject.Services.GenreOperations.CreateGenreCommand;
using static WebApiProject.Services.GenreOperations.GetByIdGenreQuery;
using static WebApiProject.Services.GenreOperations.GetGenresQuery;

namespace WebApiProject.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() //ne neye dönüşebilir config
        {
            CreateMap<CreateBookModel, Book>();  //source-target, createbookmodel objesi book objesine maplenebilsin
            CreateMap<Book, BookGetByIdViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString())); //booksviewmodel içerisindeki genre'yı belirtilen şekilde maplemek için mapfrom ile nereden mapleneceği belirtilir
            CreateMap<Book,BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreGetByIdViewModel>();
            CreateMap<CreateGenreModel, Genre>();

        }
    }
}
