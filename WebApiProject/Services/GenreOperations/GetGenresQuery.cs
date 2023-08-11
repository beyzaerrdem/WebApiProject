using AutoMapper;
using WebApiProject.DbOperations;

namespace WebApiProject.Services.GenreOperations
{
    public class GetGenresQuery
    {
        public readonly BookStoreDbContext _dbContext;
        public readonly IMapper _mapper;
        public GetGenresQuery(BookStoreDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GenreViewModel> Handle()
        {
            var genres = _dbContext.Genres.Where(x => x.IsActive == true).OrderBy(x => x.Id).ToList();

            var genreList = _mapper.Map<List<GenreViewModel>>(genres);

            return genreList;
        }

        public class GenreViewModel
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
