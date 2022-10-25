using Microsoft.AspNetCore.Mvc;
using WebApiProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiProject.DbOperations;
using WebApiProject.BookOperations;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BooksController : Controller
    {

        //private static List<Book> BookList = new List<Book>();
        
        private readonly BookStoreDbContext _context;

            
        public BooksController(BookStoreDbContext context)
        {
            _context = context;
        }



            //new Book
            //{
            //    BookId = 1,
            //    Name = "Kitap",
            //    PageCount= 199,
            //    GenreId= 1,
            //    PublishDate = new DateTime (2020,03,15)
            //},
            // new Book
            //{
            //    BookId = 2,
            //    Name = "Deneme",
            //    PageCount= 400,
            //    GenreId= 2,
            //    PublishDate = new DateTime (2015,08,22)
            //}
        //};



        [HttpGet]
        public IActionResult GetBooksList()
        {
            GetBooksQuery getBooksQuery = new GetBooksQuery(_context);
            var result = getBooksQuery.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public Book GetBookListById(int id)
        {
            var book = _context.Books.Where(Book => Book.BookId == id).SingleOrDefault();
            return book;
        }


        [HttpPost]
        public IActionResult AddBook([FromBody] Book b)
        {
            var book = _context.Books.SingleOrDefault(x => x.Name == b.Name);

            if(book != null)
            {
                return BadRequest();
            }
           
                _context.Books.Add(b);
                _context.SaveChanges();
                return Ok();
            
        }


        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] Book updatedBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.BookId == id);

            if(book != null)
            {
                return BadRequest();
            }

            else
            {
                book.Name = updatedBook.Name != default ? updatedBook.Name : book.Name;
                book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
                book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
                book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;

                _context.SaveChanges();
                return Ok();
            }

        }


        [HttpDelete("{id}")]

        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Where(Book => Book.BookId == id).SingleOrDefault();

            if(book == null)
            {
                return BadRequest();
            }

            else
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return Ok();
            }
        }
       
    }
}

