using Projekt_Back_End.Models.Domain;

namespace Projekt_Back_End.Repositories
{
    public interface IScreeningRepo
    {
        Task<IEnumerable<Screening>> GetAllAsync();

        Task<Screening> GetAsync(Guid id);

        Task<Screening> AddAsync(Screening screen);

        Task<Screening> DeleteAsync(Guid id);

        Task<Screening> UpdateAsync(Guid id, Screening screen);
    }
}
