using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ProductSizeRepository : GenericRepository<ProductSize>, IProductSizeRepository
    {
        private readonly AppDbContext _dbContext;

        public ProductSizeRepository(AppDbContext dbContext, IClaimsService claimsService) : base(dbContext, claimsService)
        {
            _dbContext = dbContext;
        }

        public async Task<ProductSize> GetByProductAndSize(Guid productId, Guid sizeId)
        {
            return await  _dbContext.ProductSizes
                .Include(_ => _.Product)
                .Include(_ => _.Size)
                .Where(_ => _.ProductID == productId && _.SizeId == sizeId).FirstOrDefaultAsync();
        }
    }
}
