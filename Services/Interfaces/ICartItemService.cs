using Repositories.Entities;
using Repositories.Models.CartItemModels;
using Services.Common;
using Services.Models.CartItemModels;
using Services.Models.CartModels;
using Services.Models.ResponseModels;

namespace Services.Interfaces
{
    public interface ICartItemService
    {
        Task<ResponseModel> Create(CartItemCreateModel cartItemCreateModel);
        Task<Pagination<CartItemModel>> GetCartItemOverview(CartItemFilterModel cartItemFilterModel);
        Task<ResponseModel> RemoveProductFromCartItem(Guid cartItemId);
        Task<ResponseModel> AdjustCartItemQuantity(Guid cartItemId, int quantity);
    }
}
