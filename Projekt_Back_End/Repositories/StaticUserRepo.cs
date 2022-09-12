using Projekt_Back_End.Models.Domain;

namespace Projekt_Back_End.Repositories
{
    public class StaticUserRepo : IUserRepository

    {
        private List<User> Users = new List<User>()
        {
        //    new User()
        //    {
        //        FirstName = "Read Only", LastName = "User", email = "readonlyuser@gmail.com", Id = Guid.NewGuid(), username = "readonlyuser", password = "123456", Roles = new List<string> {"reader"}
        //    },
        //   new User()
        //{
        //    FirstName = "Read Write", LastName = "User", email = "readwriteuser@gmail.com", Id = Guid.NewGuid(), username = "readwriteuser", password = "123456", Roles = new List<string> { "reader", "writer" }
        //    }
        };

        public async Task<User> AutheticateAsync(string username, string password)
        {
            var user = Users.Find(x => x.username.Equals(username, StringComparison.OrdinalIgnoreCase) && x.password == password);

            return user;
        }
    }
}
