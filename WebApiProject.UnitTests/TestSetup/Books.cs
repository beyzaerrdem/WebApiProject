using System.Runtime.CompilerServices;
using WebApiProject.DbOperations;
using WebApiProject.Entities;

namespace WebApiProject.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
               new Book{BookId = 8,Name = "yeni kitap",PageCount = 50,GenreId = 1,PublishDate = new DateTime(2020, 03, 15)},
               new Book{BookId = 9,Name = "erdem kitap",PageCount = 100,GenreId = 2,PublishDate = new DateTime(2020, 08, 25)}
               );
        }
    }
}
