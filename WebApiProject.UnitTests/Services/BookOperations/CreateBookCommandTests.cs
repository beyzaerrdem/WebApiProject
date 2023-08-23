using AutoMapper;
using FluentAssertions;
using WebApiProject.DbOperations;
using WebApiProject.Entities;
using WebApiProject.Services.BookOperations;
using WebApiProject.UnitTests.TestSetup;
using static WebApiProject.Services.BookOperations.CreateBookCommand;

namespace WebApiProject.UnitTests.Services.BookOperations
{
    public class CreateBookCommandTests : IClassFixture<CommanTestFixture> //Xunit özelliği : CommanTestFixtureda kullanılan mapper ve contexti constructora geçebilmek için
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommanTestFixture testFixture) 
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper; 
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange (hazırlık)
            var book = new Book(){ BookId = 10, Name = "WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount = 200, GenreId = 2, PublishDate = new DateTime(2000, 03, 15) };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = new CreateBookModel() { Name = book.Name }; //aynı isimli kitap olması exceptionu için 


            //act (çalıştırma) & assert (doğrulama)
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut"); //hangi hatayı ve hata mesajını vermeli
        }
    }
}
