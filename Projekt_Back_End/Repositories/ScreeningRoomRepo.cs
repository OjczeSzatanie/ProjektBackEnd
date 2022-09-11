using Microsoft.EntityFrameworkCore;
using Projekt_Back_End.Data;
using Projekt_Back_End.Models.Domain;

namespace Projekt_Back_End.Repositories
{
    public class ScreeningRoomRepo : IScreeningRoomRepo
    {
        private readonly BackEndDbContext backEndDbContext;

        public ScreeningRoomRepo(BackEndDbContext backEndDbContext)
        {
            this.backEndDbContext = backEndDbContext;
        }

        public async Task<Screening_Room> AddAsync(Screening_Room room)
        {
            room.Id = Guid.NewGuid();
            await backEndDbContext.AddAsync(room);
            await backEndDbContext.SaveChangesAsync();
            return room;

        }

        public async Task<Screening_Room> DeleteAsync(Guid id)
        {
            var room = await backEndDbContext.Screening_Rooms.FirstOrDefaultAsync(x => x.Id == id);

            if (room == null)
            {
                return null;
            }
            backEndDbContext.Screening_Rooms.Remove(room);
            await backEndDbContext.SaveChangesAsync();
            return room;

        }
        public async Task<IEnumerable<Screening_Room>> GetAllAsync()
        {
            return await backEndDbContext.Screening_Rooms.ToListAsync();
        }

        public async Task<Screening_Room> GetAsync(Guid id)
        {
            return await backEndDbContext.Screening_Rooms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Screening_Room> UpdateAsync(Guid id, Screening_Room room)
        {
            var existingroom = await backEndDbContext.Screening_Rooms.FirstOrDefaultAsync(x => x.Id == id);
            if (existingroom == null)
            {
                return null;
            }

            existingroom.Name = room.Name;
            existingroom.Num_Of_Seats = room.Num_Of_Seats;
           

            await backEndDbContext.SaveChangesAsync();

            return existingroom;
        }

        
    }
}
