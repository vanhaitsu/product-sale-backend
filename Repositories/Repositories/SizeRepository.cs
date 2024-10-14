using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class SizeRepository : GenericRepository<Size>, ISizeRepository
    {
        private readonly AppDbContext _dbContext;

        public SizeRepository(AppDbContext dbContext, IClaimsService claimsService) : base(dbContext, claimsService)
        {
            _dbContext = dbContext;
        }
    }
}
