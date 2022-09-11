using Microsoft.AspNetCore.Mvc;
using Projekt_Back_End.Models.Domain;
using Projekt_Back_End.Repositories;

namespace Projekt_Back_End.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class MoviesController : Controller
    {
        private readonly IMovieRepository movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = movieRepository.GetAll();
            
            // return DTO regions
            var moviesDTO = new List<Models.DTO.Movie)> ();
            movies.ToList().ForEach(movie => {

                var movieDTO = new Models.DTO.Movie()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Duration = movie.Duration,
                    Genre = movie.Genre,
                    Image = movie.Image,

                };
                moviesDTO.Add(movieDTO);
            });


            return Ok(movies);
        }
    }
}
