using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductRepository(AppDbContext dbContext, IClaimsService claimsService) : base(dbContext, claimsService)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Get(Guid id)
        {
            return await _dbContext.Products
                .Include(cp => cp.ProductImages)
                .Include(cp => cp.FeedBacks)
                .FirstOrDefaultAsync(cp => cp.Id == id);
        }
    }
}
