using Microsoft.EntityFrameworkCore;
using Projekt_Back_End.Models.Domain;

namespace Projekt_Back_End.Data
{
    public class BackEndDbContext : DbContext
    {
        public BackEndDbContext(DbContextOptions<BackEndDbContext> options): base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Movie_Key> Movie_Keys { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<Screening_Room> Screening_Rooms { get; set; }


    }

}
