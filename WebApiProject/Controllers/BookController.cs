using Microsoft.AspNetCore.Mvc;
using WebApiProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiProject.DbOperations;
using WebApiProject.BookOperations;
using static WebApiProject.BookOperations.CreateBookCommand;
using static WebApiProject.BookOperations.GetByIdQuery;
using static WebApiProject.BookOperations.UpdateBookCommand;
using static WebApiProject.BookOperations.DeleteBookCommand;
using AutoMapper;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BooksController : Controller
    {

        //private static List<Book> BookList = new List<Book>();

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
        public IActionResult GetBooksList()  //oluşturulan modeli kullanmak
        {
            GetBooksQuery getBooksQuery = new GetBooksQuery(_context,_mapper);
            var result = getBooksQuery.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetBookListById(int id)
        {
            GetByIdQuery getByIdQuery = new GetByIdQuery(_context,_mapper);
            BookGetByIdViewModel result;
            try
            {
                getByIdQuery.BookId = id;
                result = getByIdQuery.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(result);
        }


        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel b)
        {
            CreateBookCommand cm = new CreateBookCommand(_context,_mapper); //dışarıdan context alıcak

            try
            {
                cm.Model = b;
                cm.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }


        [HttpPut("{id}")]

        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel u)
        {
            var book = _context.Books.SingleOrDefault(x => x.BookId == id);

            UpdateBookCommand ub = new UpdateBookCommand(_context);
            try
            {
                ub.BookId = id;
                ub.Model = u;
                ub.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            try
            {
                command.BookId = id;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}



