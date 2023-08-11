using AutoMapper;
using WebApiProject.DbOperations;
using WebApiProject.Entities;

namespace WebApiProject.Services.GenreOperations
{
    public class CreateGenreCommand
    {
        public CreateGenreModel model { get; set; }
        public readonly BookStoreDbContext _dbContext;
        public readonly IMapper _mapper;

        public CreateGenreCommand(BookStoreDbContext dbContext, IMapper mapper) 
        { 
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == model.Name);
           
            if (genre != null)
            {
                throw new InvalidOperationException("Kategori zaten mevcut");
            }

            genre = _mapper.Map<Genre>(genre);

            _dbContext.Add(genre);
            _dbContext.SaveChanges();
        }


        public class CreateGenreModel
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
