using Assignment_Day6.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Threading.Tasks;

namespace Assignment_Day6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> movies=new List<Movie>()
        {
          new(){Id=1, Title = "Cipher Code", Genre = "Action", ReleaseYear =2023},
          new (){Id=2, Title = "Aasman Ki Or", Genre = "Adventure", ReleaseYear = 2023 },
          new (){Id=3,  Title = "Dil Se Dosti", Genre = "Friendship", ReleaseYear = 2022 },
          new(){ Id=4, Title = "Pushpa", Genre = "Action", ReleaseYear = 2022 }

        };
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            var task = movies.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] Movie movie)
        {
            movie.Id = movies.Count + 1;
            movies.Add(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie updatedMovie)
        {
            var movie = movies.FirstOrDefault(t => t.Id == id);
            if (movie == null)
                return NotFound();

            movie.Title = updatedMovie.Title;
            movie.Genre = updatedMovie.Genre;
            movie.ReleaseYear = updatedMovie.ReleaseYear;
              
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var movie = movies.FirstOrDefault(t => t.Id == id);
            if (movie == null)
                return NotFound();

            movies.Remove(movie);
            return NoContent();
        }
    }

}

