

using AutoMapper;
using WebApiProject.Coomon;
using WebApiProject.DbOperations;

namespace WebApiProject.Services.BookOperations
{
    public class GetByIdQuery
    {
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;

        public GetByIdQuery(BookStoreDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public int BookId { get; set; }


        public BookGetByIdViewModel Handle()
        {
            //getBooks gibi list yapmadık çünkü liste deil idye göre
            var book = _dbcontext.Books.Where(x => x.BookId == BookId).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap bulunamadı.");
            }
            BookGetByIdViewModel bm = _mapper.Map<BookGetByIdViewModel>(book);

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
