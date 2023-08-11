using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiProject.DbOperations;
using WebApiProject.Entities;

namespace WebApiProject.Services.AuthorOperations
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel model { get; set; }

        public readonly BookStoreDbContext _dbContext;
        public readonly IMapper _mapper;

        public CreateAuthorCommand(BookStoreDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public void Handle()
        {
            var auth = _dbContext.Authors.Where(x => x.Name == model.Name && x.Surname == model.Surname).SingleOrDefault();

            if (auth != null)
            {
                throw new InvalidOperationException("Yazar zaten mevcut");
            }

            var author = _mapper.Map<Author>(auth);

            _dbContext.Add(author);
            _dbContext.SaveChanges();
        }

        public class CreateAuthorModel
        {
            public string Name { get; set; }

            public string Surname { get; set; }

            public DateTime BirthdayDate { get; set; }
        }
    }
}
