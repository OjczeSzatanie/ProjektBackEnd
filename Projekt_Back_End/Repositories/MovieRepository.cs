using Microsoft.EntityFrameworkCore;
using Projekt_Back_End.Data;
using Projekt_Back_End.Models.Domain;

namespace Projekt_Back_End.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly BackEndDbContext backEndDbContext;
        
        public MovieRepository(BackEndDbContext backEndDbContext)
        {
            this.backEndDbContext = backEndDbContext;
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
           movie.Id = Guid.NewGuid();
           await backEndDbContext.AddAsync(movie);
           await backEndDbContext.SaveChangesAsync();
            return movie;

        }

        public async Task<Movie> DeleteAsync(Guid id)
        {
            var movie = await backEndDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);

            if (movie == null)
            {
                return null;
            }
            backEndDbContext.Movies.Remove(movie);
            await backEndDbContext.SaveChangesAsync();
            return movie;

        }
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await backEndDbContext.Movies.ToListAsync();
        }

        public async Task<Movie> GetAsync(Guid id)
        {
            return await backEndDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<Movie> UpdateAsync(Guid id, Movie movie)
        {
           var existingmovie =  await backEndDbContext.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (existingmovie == null)
            {
                return null;
            }

            existingmovie.Title = movie.Title;
            existingmovie.Duration = movie.Duration;
            existingmovie.Genre = movie.Genre;
            existingmovie.Image = movie.Image;

            await backEndDbContext.SaveChangesAsync();

            return existingmovie;
        }
    }
}
