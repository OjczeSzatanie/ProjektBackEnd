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
    
        public IEnumerable<Movie> GetAll()
        {
            return backEndDbContext.Movies.ToList();
        }
    }
}
