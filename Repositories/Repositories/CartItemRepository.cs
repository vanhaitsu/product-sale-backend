using Microsoft.EntityFrameworkCore;
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
        public async Task<CartItem> GetCartItem(Guid cartItemId)
        {
            return await _dbContext.CartItems
                .FirstOrDefaultAsync(_ => _.Id == cartItemId); 
        }
    }
}
