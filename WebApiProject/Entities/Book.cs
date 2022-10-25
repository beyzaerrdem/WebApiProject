using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiProject.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public string Name{ get; set; }

        public int PageCount { get; set; }

        public int GenreId { get; set; }

        public DateTime PublishDate { get; set; }
    }
}

