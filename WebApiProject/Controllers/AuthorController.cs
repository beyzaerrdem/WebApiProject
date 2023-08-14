using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.DbOperations;
using WebApiProject.Services.AuthorOperations;
using static WebApiProject.Services.AuthorOperations.CreateAuthorCommand;
using static WebApiProject.Services.AuthorOperations.GetByIdAuthorQuery;
using static WebApiProject.Services.AuthorOperations.UpdateAuthorCommand;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery g = new GetAuthorsQuery(_context, _mapper);
            var authorList = g.Handle();
            return Ok(authorList);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            GetByIdAuthorQuery g = new GetByIdAuthorQuery(_context, _mapper);
            AuthorGetByIdModel result;
            try
            {
                g.AuthorId = id;
                result = g.Handle();
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);   
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel model)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            try
            {
                command.model = model;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel model)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand( _context, _mapper);

            try
            {
                command.AuthorId = id;
                command.model = model;
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context);

            try
            {
                command.AuthorId = id;
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
