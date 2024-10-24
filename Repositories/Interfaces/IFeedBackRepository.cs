using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IFeedBackRepository : IGenericRepository<FeedBack>
    {
        Task<FeedBack> CheckFeedBackAlready(Guid accountId, Guid productId);
        Task<List<FeedBack>> GetFeedBacksByProductId(Guid productId);

    }
}
