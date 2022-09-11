using Projekt_Back_End.Models.Domain;

namespace Projekt_Back_End.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
    }
}
