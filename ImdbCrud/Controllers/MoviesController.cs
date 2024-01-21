using ImdbCrud.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ImdbCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController:ControllerBase
    {
        private readonly MovieDbContext Context;
        public MoviesController(MovieDbContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = Context.movies.ToList();
            return Ok(movies);
        }
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var movie = Context.movies.Find(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }
        [HttpPost]
        public IActionResult AddMovie([FromBody] Movies movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Context.movies.Add(movie);
            Context.SaveChanges();

            return CreatedAtAction(nameof(GetMovieById), new { id = movie.id }, movie);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movies newMovie)
        {
            var oldMovie = Context.movies.Find(id);
            if (oldMovie == null)
                return NotFound();

            oldMovie.Title = newMovie.Title;
            oldMovie.Director = newMovie.Director;
            oldMovie.ReleaseYear = newMovie.ReleaseYear;

           Context.SaveChanges();

            return Ok(oldMovie);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movie = Context.movies.Find(id);
            if (movie == null)
                return NotFound();

            Context.movies.Remove(movie);
            Context.SaveChanges();

            return NoContent();
        }
    }
}
