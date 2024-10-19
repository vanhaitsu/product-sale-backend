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
                                   .Include(_ => _.Account)
                                   .Include(_ => _.CartItems)
                                   .ThenInclude(_ => _.ProductSize)
                                   .ThenInclude(_ => _.Size)
                                   .Include(_ => _.CartItems)
                                   .ThenInclude(_ => _.ProductSize.Product)
                                   .FirstOrDefaultAsync(_ => _.AccountID == accountId);
        }
        public async Task<Cart> GetById(Guid cartId)
        {
            return await _dbContext.Carts
                                   .Include(_ => _.Account)
                                   .Include(_ => _.CartItems)
                                   .ThenInclude(_ => _.ProductSize)
                                   .ThenInclude(_ => _.Size)
                                   .Include(_ => _.CartItems)
                                   .ThenInclude(_ => _.ProductSize.Product)
                                   .FirstOrDefaultAsync(_ => _.Id == cartId);
        }
    }
}
