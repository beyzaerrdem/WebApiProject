using AutoMapper;
using WebApiProject.DbOperations;

namespace WebApiProject.Services.AuthorOperations
{
    public class GetByIdAuthorQuery
    {
        public readonly BookStoreDbContext _dbContext;
        public readonly IMapper _mapper;
        public GetByIdAuthorQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int AuthorId { get; set; }

        public AuthorGetByIdModel Handle()
        {
            var authorId = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if (authorId is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı.");
            }

            AuthorGetByIdModel author = _mapper.Map<AuthorGetByIdModel>(authorId);
            return author;
        }


        public class AuthorGetByIdModel
        {
            public string Name { get; set; }

            public string Surname { get; set; }

            public DateTime BirthdayDate { get; set; }
        }
    }
}
