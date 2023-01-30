using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkDificultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public WalkDificultyRepository(NZWalksDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();

            await _dbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await _dbContext.SaveChangesAsync();

            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var walkDifficulty = await _dbContext.WalkDifficulty.FindAsync(id);

            if (walkDifficulty == null)
            {
                return null;
            }

            _dbContext.Remove(walkDifficulty);
            await _dbContext.SaveChangesAsync();

            return walkDifficulty;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await _dbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await _dbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await _dbContext.WalkDifficulty.FindAsync(id);

            if (existingWalkDifficulty == null)
            {
                return null;
            }

            existingWalkDifficulty.Code = walkDifficulty.Code;

            await _dbContext.SaveChangesAsync();

            return existingWalkDifficulty;
        }
    }
}
