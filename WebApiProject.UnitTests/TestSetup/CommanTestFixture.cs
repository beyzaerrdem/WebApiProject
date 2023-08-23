using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApiProject.DbOperations;
using WebApiProject.Mapping;

namespace WebApiProject.UnitTests.TestSetup
{
    public class CommanTestFixture //uygulamada kullanılan context ve mapper yerine test projesinde oluşturmak için
    {
        public BookStoreDbContext Context { get; set; }

        public IMapper Mapper { get; set; }

        public CommanTestFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName: "BookStoreTestDb").Options;
            Context = new BookStoreDbContext(options);

            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}
