using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        private readonly AppDbContext _dbContext;

        public BrandRepository(AppDbContext dbContext, IClaimsService claimsService) : base(dbContext, claimsService)
        {
            _dbContext = dbContext;
        }
    }
}
