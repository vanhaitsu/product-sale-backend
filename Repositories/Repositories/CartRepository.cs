using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly AppDbContext _dbContext;

        public CartRepository(AppDbContext dbContext, IClaimsService claimsService) : base(dbContext, claimsService)
        {
            _dbContext = dbContext;
        }

        public async Task<Cart> GetByAccount(Guid accountId)
        {
            return await _dbContext.Carts
                .FirstOrDefaultAsync(cp => cp.AccountID == accountId);
        }
        public async Task<Cart> GetById(Guid cartId)
        {
            return await _dbContext.Carts
                .FirstOrDefaultAsync(_ => _.Id == cartId);
        }
    }
}
