using Projekt_Back_End.Models.Domain;

namespace Projekt_Back_End.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();

        Task<Movie>GetAsync(Guid id);

        Task<Movie> AddAsync(Movie movie);

        Task<Movie> DeleteAsync(Guid id);

        Task<Movie> UpdateAsync(Guid id, Movie movie);

    }
}
