using AutoMapper;
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
        private readonly IMapper mapper;

        public MoviesController(IMovieRepository movieRepository, IMapper mapper)
        {
            this.movieRepository = movieRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMoviesAsync()
        {
            var movies = await movieRepository.GetAllAsync();

            // return DTO regions
            //var moviesDTO = new List<Models.DTO.Movie>();
            //movies.ToList().ForEach(movie => {

            //    var movieDTO = new Models.DTO.Movie()
            //    {
            //        Id = movie.Id,
            //        Title = movie.Title,
            //        Duration = movie.Duration,
            //        Genre = movie.Genre,
            //        Image = movie.Image,

            //    };
            //    moviesDTO.Add(movieDTO);
            //});

            var moviesDTO = mapper.Map<List<Models.DTO.Movie>>(movies);
            return Ok(moviesDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetMovieAsync")]
        public async Task<IActionResult> GetMovieAsync(Guid id)
        {
            var movie = await movieRepository.GetAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            var movieDTO = mapper.Map<Models.DTO.Movie>(movie);

            return Ok(movieDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieAsync(Models.DTO.AddMovieRequest addMovieRequest)
        {
            // Request(DTO) to Domain Model
            var movie = new Models.Domain.Movie()
            {
                Title = addMovieRequest.Title,
                Duration = addMovieRequest.Duration,
                Genre = addMovieRequest.Genre,
                Image = addMovieRequest.Image
            };

            //Pass details to Repository
            movie = await movieRepository.AddAsync(movie);

            //Convert back to DTO
            var movieDTO = new Models.DTO.Movie()
            {
                Id = movie.Id,
                Title = movie.Title,
                Duration = movie.Duration,
                Genre = movie.Genre,
                Image = movie.Image
            };

            return CreatedAtAction(nameof(GetMovieAsync), new { id = movieDTO.Id }, movieDTO);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteMovieAsync(Guid id)
        {
            // Get movie from database
            var movie = await movieRepository.DeleteAsync(id);

            //if null notfound
            if(movie == null)
            {
                return NotFound();
            }

            //Convert response back to DTO

            var movieDTO = new Models.DTO.Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Duration = movie.Duration,
                Genre = movie.Genre,
                Image = movie.Image
            };

            //response back to the client
            return Ok(movieDTO);
    
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateMovieRequest updateMovieRequest)
        {
            //Convert dto to domain
            var movie = new Models.Domain.Movie()
            {
                Title = updateMovieRequest.Title,
                Duration = updateMovieRequest.Duration,
                Genre = updateMovieRequest.Genre,
                Image = updateMovieRequest.Image
            };

            //update movie
             movie = await movieRepository.UpdateAsync(id, movie);

            // if null not found
            if (movie == null)
            {
                return NotFound();
            }

            //convert domain to dto
            var movieDTO = new Models.DTO.Movie()
            {
                Id = movie.Id,
                Title = movie.Title,
                Duration = movie.Duration,
                Genre = movie.Genre,
                Image = movie.Image
            };
            //return ok
            return Ok(movieDTO);
        }
    }
}
