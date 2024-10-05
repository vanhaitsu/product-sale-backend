using Repositories.Entities;

namespace Repositories.Interfaces
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart> GetByAccount(Guid accountId);
        Task<Cart> GetById(Guid cartId);
    }
}
