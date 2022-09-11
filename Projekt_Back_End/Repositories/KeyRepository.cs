using Microsoft.EntityFrameworkCore;
using Projekt_Back_End.Data;
using Projekt_Back_End.Models.Domain;

namespace Projekt_Back_End.Repositories
{
    public class KeyRepository : IKeyRepository
    {
        private readonly BackEndDbContext backEndDbContext;

        public KeyRepository(BackEndDbContext backEndDbContext)
        {
            this.backEndDbContext = backEndDbContext;
        }

        public async Task<Movie_Key> AddAsync(Movie_Key key)
        {
            key.Id = Guid.NewGuid();
            await backEndDbContext.AddAsync(key);
            await backEndDbContext.SaveChangesAsync();
            return key;
        }

        public async Task<Movie_Key> DeleteAsync(Guid id)
        {
            var key = await backEndDbContext.Movie_Keys.FirstOrDefaultAsync(x => x.Id == id);

            if (key == null)
            {
                return null;
            }
            backEndDbContext.Movie_Keys.Remove(key);
            await backEndDbContext.SaveChangesAsync();
            return key;

        }

        public async Task<IEnumerable<Movie_Key>> GetAllAsync()
        {
            return await backEndDbContext.Movie_Keys.ToListAsync();
        }

        public async Task<Movie_Key> GetAsync(Guid id)
        {
            return await backEndDbContext.Movie_Keys.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Movie_Key> UpdateAsync(Guid id, Movie_Key key)
        {
            var existingkey = await backEndDbContext.Movie_Keys.FirstOrDefaultAsync(x => x.Id == id);
            if (existingkey == null)
            {
                return null;
            }
            existingkey.Time_Of_Start = key.Time_Of_Start;
            existingkey.Time_Of_End = key.Time_Of_End;
            existingkey.MovieId = key.MovieId;
            

            await backEndDbContext.SaveChangesAsync();

            return existingkey;
        }
        }
}
