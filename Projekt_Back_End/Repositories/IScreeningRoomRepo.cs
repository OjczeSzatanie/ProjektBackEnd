using Projekt_Back_End.Models.Domain;

namespace Projekt_Back_End.Repositories
{
    public interface IScreeningRoomRepo
    {
        Task<IEnumerable<Screening_Room>> GetAllAsync();

        Task<Screening_Room> GetAsync(Guid id);

        Task<Screening_Room> AddAsync(Screening_Room room);

        Task<Screening_Room> DeleteAsync(Guid id);

        Task<Screening_Room> UpdateAsync(Guid id, Screening_Room room);
    }
}
