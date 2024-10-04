using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        private readonly AppDbContext _dbContext;

        public CartItemRepository(AppDbContext dbContext, IClaimsService claimsService) : base(dbContext, claimsService)
        {
            _dbContext = dbContext;
        }
    }
}
