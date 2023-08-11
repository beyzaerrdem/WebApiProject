using AutoMapper;
using WebApiProject.DbOperations;

namespace WebApiProject.Services.GenreOperations
{
    public class GetByIdGenreQuery
    {
        public readonly BookStoreDbContext _dbContext;
        public readonly IMapper _mapper;

        public GetByIdGenreQuery(BookStoreDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int GenreId { get; set; }

        public GenreGetByIdViewModel Handle() 
        { 
            var genreId = _dbContext.Genres.Where(x => x.Id == GenreId).SingleOrDefault();

            GenreGetByIdViewModel genre = _mapper.Map<GenreGetByIdViewModel>(genreId);

            return genre;
        
        }

        public class GenreGetByIdViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
