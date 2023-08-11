using WebApiProject.DbOperations;

namespace WebApiProject.Services.AuthorOperations
{
    public class DeleteAuthorCommand
    {
        public readonly BookStoreDbContext _dbContext;
        public DeleteAuthorCommand(BookStoreDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public int AuthorId { get; set; }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if(author == null)
            {
                throw new InvalidOperationException("Silinecek yazar bulunamadı");
            }
            _dbContext.Remove(author);
            _dbContext.SaveChanges();
        }
    }
}
