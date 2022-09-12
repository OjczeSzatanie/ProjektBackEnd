using Microsoft.EntityFrameworkCore;
using Projekt_Back_End.Data;
using Projekt_Back_End.Models.Domain;

namespace Projekt_Back_End.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BackEndDbContext backEndDbConxtext;

        public UserRepository(BackEndDbContext backEndDbContext)
        {
            this.backEndDbConxtext = backEndDbContext;
        }
        public async Task<User> AutheticateAsync(string userName, string passWord)
        {
           var user =  await backEndDbConxtext.Users
                .FirstOrDefaultAsync(x => x.username.ToLower() == userName.ToLower() && x.password == passWord);

            if(user == null)
            {
                return null;
            }

            var userRoles = await backEndDbConxtext.User_Roles.Where(x => x.UserId == user.Id).ToListAsync();

            if (userRoles.Any())
            {
                user.Roles = new List<string>();

                foreach(var userRole in userRoles)
                {
                    var role = await backEndDbConxtext.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                    if(role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }
            user.password = null;
            return user;
            
        }
    }
}
