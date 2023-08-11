using Microsoft.EntityFrameworkCore;
using WebApiProject.Entities;

namespace WebApiProject.DbOperations
{
    public class DataGenerator
    {
        public static void Initalize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Genres.AddRange(new Genre{
                    Name = "personel growth"
                },
                new Genre
                {
                    Name = "science fiction"
                });

                context.Authors.AddRange(new Author
                {
                    Name = "Beyza",
                    Surname = "Erdem",
                    BirthdayDate = new DateTime(2000, 04, 02)
                });

                context.Books.AddRange(new Book
                {
                    BookId = 8,
                    Name = "yeni kitap",
                    PageCount = 50,
                    GenreId = 1, // personel growth
                    PublishDate = new DateTime(2020, 03, 15)
                },
                new Book
                {
                    BookId = 9,
                    Name = "erdem kitap",
                    PageCount = 100,
                    GenreId = 2, // science fiction
                    PublishDate = new DateTime(2020, 08, 25)
                });

                context.SaveChanges();
            }
        }
    }
}
