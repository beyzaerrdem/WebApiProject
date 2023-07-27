using AutoMapper;
using WebApiProject.Coomon;
using WebApiProject.DbOperations;
using WebApiProject.Entities;

namespace WebApiProject.BookOperations
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BookViewModel> Handle()  //modele çevirdik
        {
            var bookList = _dbContext.Books.OrderBy(x => x.BookId).ToList<Book>();
            List<BookViewModel> vm = _mapper.Map<List<BookViewModel>>(bookList);

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
