using Repositories.Entities;

namespace Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product> Get(Guid id);
    }
}
