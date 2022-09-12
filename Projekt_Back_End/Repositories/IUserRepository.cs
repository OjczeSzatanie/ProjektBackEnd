using Projekt_Back_End.Models.Domain;

namespace Projekt_Back_End.Repositories
{
    public interface IUserRepository
    {
        Task<User> AutheticateAsync(string userName, string passWord);
    }
}
