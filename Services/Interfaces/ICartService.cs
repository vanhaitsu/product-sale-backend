using Repositories.Entities;
using Services.Models.ResponseModels;

namespace Services.Interfaces
{
    public interface ICartService
    {
        Task<ResponseDataModel<Cart>> Create(Guid accountId);
        Task<ResponseModel> ClearCart(Guid cartId);
    }
}
