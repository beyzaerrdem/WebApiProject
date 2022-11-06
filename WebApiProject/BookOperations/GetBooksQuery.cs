using WebApiProject.Coomon;
using WebApiProject.DbOperations;
using WebApiProject.Entities;

namespace WebApiProject.BookOperations
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<BookViewModel> Handle()  //modele çevirdik
        {
            var bookList = _dbContext.Books.OrderBy(x => x.BookId).ToList<Book>();
            List<BookViewModel> vm = new List<BookViewModel>();
            foreach (var item in bookList)
            {
                vm.Add(new BookViewModel()
                {
                    Name = item.Name,
                    PageCount = item.PageCount,
                    Genre = ((GenreEnum)item.GenreId).ToString(),
                    PublishDate = item.PublishDate.Date.ToString("dd/MM/yyy"),
                });

            }
            return vm;
        }




        public class BookViewModel
        {
            public string Name { get; set; }

            public int PageCount { get; set; }

            public string Genre { get; set; }

            public string PublishDate { get; set; }
        }


    }
}
