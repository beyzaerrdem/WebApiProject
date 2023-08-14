using AutoMapper;
using WebApiProject.DbOperations;

namespace WebApiProject.Services.AuthorOperations
{
    public class UpdateAuthorCommand
    {
        public readonly IBookStoreDbContext _dbContext;
        public readonly IMapper _mapper;
        public UpdateAuthorCommand(IBookStoreDbContext dbContext, IMapper mapper) 
        { 
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int AuthorId { get; set; }

        public UpdateAuthorModel model { get; set; }

        public void Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(x => x.Id == AuthorId);

            if(author == null)
            {
                throw new Exception("Yazar bulunamadı.");
            }

            author.Name = model.Name != default ? model.Name : author.Name;
            author.Surname = model.Surname != default ? model.Surname : author.Surname;
            author.BirthdayDate = model.BirthdayDate != default ? model.BirthdayDate : author.BirthdayDate;

            _dbContext.SaveChanges();
        }

        public class UpdateAuthorModel
        {
            public string Name { get; set; }

            public string Surname { get; set; }

            public DateTime BirthdayDate { get; set; }
        }
    }
}
