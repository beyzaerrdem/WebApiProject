using WebApiProject.DbOperations;

namespace WebApiProject.BookOperations
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbcontext;
        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public UpdateBookModel Model { get; set; } //dışdarıdan parametre olarak alınabilmesi lazım

        public int BookId { get; set; }

        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(x => x.BookId == BookId);

            if (book != null)
            {
                throw new InvalidOperationException("Güncellenecek kitap bulunamadı");
            }

            book.Name = Model.Name != default ? Model.Name : book.Name; //defaulttan farklı trueysa Model falsed
            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            //book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            //book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;

            _dbcontext.SaveChanges();
        }

        public class UpdateBookModel //model update için mantıklı çünkü bie entity içerisindeki her field ı update etmeyebilirsiniz
        {
            public string Name { get; set; }

            public int GenreId { get; set; }
        }
    }
}
