using AutoMapper;
using WebApiProject.DbOperations;

namespace WebApiProject.Services.AuthorOperations
{
    public class GetAuthorsQuery
    {
        public readonly IBookStoreDbContext _dbContext;
        public readonly IMapper _mapper;

        public GetAuthorsQuery(IBookStoreDbContext dbContext, IMapper mapper) 
        { 
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle() 
        { 
            var authorList = _dbContext.Authors.OrderBy(x => x.Id).ToList();
            var authors = _mapper.Map<List<AuthorViewModel>>(authorList);
            return authors;        
        }

        public class AuthorViewModel
        {
            public string Name { get; set; }

            public string Surname { get; set; }

            public DateTime BirthdayDate { get; set; }
        }
    }
}
