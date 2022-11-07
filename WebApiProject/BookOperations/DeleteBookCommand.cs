using WebApiProject.DbOperations;

namespace WebApiProject.BookOperations
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbcontext;
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public int BookId { get; set; }

        public void Handle()
        {
            var book = _dbcontext.Books.Where(Book => Book.BookId == BookId).SingleOrDefault();

            if (book == null)
            {
                throw new InvalidOperationException("Silinecek kitap bulunamadı.");
            }   
                _dbcontext.Books.Remove(book);
                _dbcontext.SaveChanges();
                
        }
    }
}
