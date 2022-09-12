using Projekt_Back_End.Models.Domain;

namespace Projekt_Back_End.Repositories
{
    public interface ITokenHandler
    {
       Task<string> CreateTokenAsync(User user);
    }
}
