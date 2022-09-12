using Microsoft.EntityFrameworkCore;
using Projekt_Back_End.Models.Domain;

namespace Projekt_Back_End.Data
{
    public class BackEndDbContext : DbContext
    {
        public BackEndDbContext(DbContextOptions<BackEndDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Role>()
                .HasOne(x => x.Role)
                .WithMany(y => y.UserRoles)
                .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<User_Role>()
               .HasOne(x => x.User)
               .WithMany(y => y.UserRoles)
               .HasForeignKey(x => x.UserId);
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Movie_Key> Movie_Keys { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Screening_Room> Screening_Rooms { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User_Role> User_Roles { get; set; }




    }

}
