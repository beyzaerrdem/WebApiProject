using WebApiProject.DbOperations;
using WebApiProject.Entities;

namespace WebApiProject.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context) 
        {
            context.Genres.AddRange(
                new Genre { Name = "personel growth" },
                new Genre { Name = "science fiction" });
        }
    }
}
