

using WebApiProject.Coomon;
using WebApiProject.DbOperations;

namespace WebApiProject.BookOperations
{
    public class GetByIdQuery
    {
        private readonly BookStoreDbContext _dbcontext;

        public GetByIdQuery(BookStoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public int BookId { get; set; }


        public BookGetByIdViewModel Handle()
        {
            //getBooks gibi list yapmadık çünkü liste deil idye göre
            var book = _dbcontext.Books.Where(Book => Book.BookId == BookId).SingleOrDefault(); 
            if(book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            BookGetByIdViewModel bm = new BookGetByIdViewModel();
            bm.Name = book.Name;
            bm.PageCount = book.PageCount;
            bm.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy");
            bm.Genre = ((GenreEnum)book.GenreId).ToString();
                          
            return bm;
        }



        public class BookGetByIdViewModel
        {
         
            public string Name { get; set; }

            public int PageCount { get; set; }

            public string Genre { get; set; }

            public string PublishDate { get; set; }
        }




    }
}
