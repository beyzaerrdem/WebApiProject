using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.DbOperations;
using WebApiProject.Services.BookOperations;
using WebApiProject.Services.GenreOperations;
using static WebApiProject.Services.GenreOperations.CreateGenreCommand;
using static WebApiProject.Services.GenreOperations.GetByIdGenreQuery;
using static WebApiProject.Services.GenreOperations.UpdateGenreCommand;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenreList()
        {
            GetGenresQuery genreList = new GetGenresQuery(_context, _mapper);
            var result = genreList.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenre(int id)
        {
            GetByIdGenreQuery genre = new GetByIdGenreQuery(_context, _mapper);

            GenreGetByIdViewModel result;

            try
            {
                genre.GenreId = id;
                result = genre.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel model)
        {
            CreateGenreCommand genre = new CreateGenreCommand(_context, _mapper);

            try
            {
                genre.model = model;
                genre.Handle();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateGenre(int id,[FromBody] UpdateGenreModel model)
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == id);

            UpdateGenreCommand g = new UpdateGenreCommand(_context, _mapper);

            try
            {
                g.GenreId = id;
                g.model = model;
                g.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand dg = new DeleteGenreCommand(_context);
            try
            {
                dg.GenreId = id;
                dg.Handle();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
