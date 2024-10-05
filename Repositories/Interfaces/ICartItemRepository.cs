using Repositories.Entities;

namespace Repositories.Interfaces
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<CartItem> GetCartItem(Guid cartItemId);
    }
}
