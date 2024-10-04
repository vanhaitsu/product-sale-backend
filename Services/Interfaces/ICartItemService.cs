using Services.Models.CartModels;
using Services.Models.ResponseModels;

namespace Services.Interfaces
{
    public interface ICartItemService
    {
        Task<ResponseModel> Create(CartItemCreateModel cartItemCreateModel);
    }
}
