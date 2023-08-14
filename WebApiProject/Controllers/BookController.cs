using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.DbOperations;
using WebApiProject.Services.BookOperations;
using WebApiProject.Validator;
using static WebApiProject.Services.BookOperations.CreateBookCommand;
using static WebApiProject.Services.BookOperations.GetByIdQuery;
using static WebApiProject.Services.BookOperations.UpdateBookCommand;

namespace WebApiProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BooksController : Controller
    {

        //private static List<Book> BookList = new List<Book>();

        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BooksController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

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
                GetByIdValidator validator = new GetByIdValidator();
                validator.ValidateAndThrow(getByIdQuery);
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
                CreateBookValidator validator = new CreateBookValidator();
                //ValidationResult result = validator.Validate(cm);
                validator.ValidateAndThrow(cm);
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
                UpdateBookValidator validator = new UpdateBookValidator();
                validator.ValidateAndThrow(ub);
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
                DeleteBookValidator validator = new DeleteBookValidator();
                validator.ValidateAndThrow(command);
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



