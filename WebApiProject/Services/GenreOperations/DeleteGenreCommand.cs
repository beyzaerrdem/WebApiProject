using AutoMapper;
using WebApiProject.DbOperations;

namespace WebApiProject.Services.GenreOperations
{
    public class DeleteGenreCommand
    {
        public readonly BookStoreDbContext _dbContext;

        public DeleteGenreCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int GenreId { get; set; }

        public void Handle()
        {
            var genre = _dbContext.Genres.Where(x => x.Id == GenreId);

            if(genre == null)
            {
                throw new Exception("Kategori bulunamadı.");
            }

            _dbContext.Remove(genre);
            _dbContext.SaveChanges();
        }
    }
}
