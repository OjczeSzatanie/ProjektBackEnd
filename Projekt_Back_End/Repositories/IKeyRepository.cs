using Projekt_Back_End.Models.Domain;

namespace Projekt_Back_End.Repositories
{
    public interface IKeyRepository
    {
        Task<IEnumerable<Movie_Key>> GetAllAsync();

        Task<Movie_Key> GetAsync(Guid id);

        Task<Movie_Key> AddAsync(Movie_Key key);

        Task<Movie_Key> DeleteAsync(Guid id);

        Task<Movie_Key> UpdateAsync(Guid id, Movie_Key key);
    }
}
