using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt_Back_End.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        [NotMapped]
        public List<string> Roles { get; set; }

        public List<User_Role> UserRoles { get; set; }

    }
}
