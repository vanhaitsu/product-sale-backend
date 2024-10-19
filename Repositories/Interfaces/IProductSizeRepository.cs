using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IProductSizeRepository : IGenericRepository<ProductSize>
    {
        Task<ProductSize> GetByProductAndSize(Guid productId, Guid sizeId);
    }
}
