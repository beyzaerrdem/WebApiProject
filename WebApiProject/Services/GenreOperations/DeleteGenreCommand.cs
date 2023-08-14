using AutoMapper;
using WebApiProject.DbOperations;

namespace WebApiProject.Services.GenreOperations
{
    public class DeleteGenreCommand
    {
        public readonly IBookStoreDbContext _dbContext;

        public DeleteGenreCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int GenreId { get; set; }

        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Id == GenreId);

            if(genre == null)
            {
                throw new Exception("Kategori bulunamadı.");
            }

            _dbContext.Genres.Remove(genre);
            _dbContext.SaveChanges();
        }
    }
}
