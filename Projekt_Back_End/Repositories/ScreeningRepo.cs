using Microsoft.EntityFrameworkCore;
using Projekt_Back_End.Data;
using Projekt_Back_End.Models.Domain;
namespace Projekt_Back_End.Repositories
{

    public class ScreeningRepo : IScreeningRepo
    {
        private readonly BackEndDbContext backEndDbContext;

        public ScreeningRepo(BackEndDbContext backEndDbContext)
        {
            this.backEndDbContext = backEndDbContext;
        }

        public async Task<Screening> AddAsync(Screening screen)
        {
            screen.Id = Guid.NewGuid();
            await backEndDbContext.AddAsync(screen);
            await backEndDbContext.SaveChangesAsync();
            return screen;
        }

        public async Task<Screening> DeleteAsync(Guid id)
        {
            var screen = await backEndDbContext.Screenings.FirstOrDefaultAsync(x => x.Id == id);

            if (screen == null)
            {
                return null;
            }
            backEndDbContext.Screenings.Remove(screen);
            await backEndDbContext.SaveChangesAsync();
            return screen;

        }

        public async Task<IEnumerable<Screening>> GetAllAsync()
        {
            return await backEndDbContext.Screenings.ToListAsync();
        }

        public async Task<Screening> GetAsync(Guid id)
        {
            return await backEndDbContext.Screenings.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Screening> UpdateAsync(Guid id, Screening screen)
        {
            var existingscreen = await backEndDbContext.Screenings.FirstOrDefaultAsync(x => x.Id == id);
            if (existingscreen == null)
            {
                return null;
            }
            existingscreen.Time_Of_Start = screen.Time_Of_Start;
            existingscreen.Time_Of_End = screen.Time_Of_End;
            existingscreen.MovieId = screen.MovieId;
            existingscreen.RoomId = screen.RoomId;



            await backEndDbContext.SaveChangesAsync();

            return existingscreen;
        }
    }
}
