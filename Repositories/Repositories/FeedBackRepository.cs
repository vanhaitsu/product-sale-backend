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
    public class FeedBackRepository : GenericRepository<FeedBack>, IFeedBackRepository
    {
        private readonly AppDbContext _dbContext;

        public FeedBackRepository(AppDbContext dbContext, IClaimsService claimsService) : base(dbContext, claimsService)
        {
            _dbContext = dbContext;
        }

        public async Task<FeedBack> CheckFeedBackAlready(Guid accountId, Guid productId)
        {
            var feedBack = await _dbContext.FeedBacks.Where(_ => _.AccountID == accountId && _.ProductID == productId).FirstOrDefaultAsync();
            if (feedBack != null)
            {
                return feedBack;
            }
            return null;
        }

        public async Task<List<FeedBack>> GetFeedBacksByProductId(Guid productId)
        {
            var getFeedBacks = await _dbContext.FeedBacks.Where(_ => _.ProductID == productId).ToListAsync();
            return getFeedBacks;
        }
    }
}
