using AutoMapper;
using WebApiProject.DbOperations;

namespace WebApiProject.Services.GenreOperations
{
    public class UpdateGenreCommand
    {
        public UpdateGenreModel model { get; set; }
        public readonly IBookStoreDbContext _dbContext;
        public readonly IMapper _mapper;
        public UpdateGenreCommand(IBookStoreDbContext dbContext, IMapper mapper) 
        { 
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int GenreId { get; set; }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);

            if(genre == null)
            {
                throw new InvalidOperationException("Güncellenecek kategori bulunamadı");
            }

            genre.Name = model.Name != default ? model.Name : genre.Name; 

            _dbContext.SaveChanges();
        }


        public class UpdateGenreModel
        {
            public string Name { get; set; }
        }
    }
}
