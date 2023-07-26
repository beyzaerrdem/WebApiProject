﻿using AutoMapper;
using WebApiProject.DbOperations;
using WebApiProject.Entities;

namespace WebApiProject.BookOperations
{
    public class CreateBookCommand
    {
        public CreateBookModel Model { get; set; } //entityi yaratıp gelen fieldları model içerisinde setlemek için

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Name == Model.Name);

            if (book != null)
            {
                throw new InvalidOperationException("Kitap zaten mevcut");
            }

            book = _mapper.Map<Book>(Model); //model ile gelen veriyi book'a maple
            //book = new Book();
            //book.Name = Model.Name; //maplemeden önceki hali
            //book.PageCount = Model.PageCount;
            //book.PublishDate = Model.PublishDate;
            //book.GenreId = Model.GenreId;

            _dbContext.Add(book);
            _dbContext.SaveChanges();
   
        }

        public class CreateBookModel
        {
            public string Name { get; set; }

            public int PageCount { get; set; }

            public int GenreId { get; set; }

            public DateTime PublishDate { get; set; }
        }

    }
}
