using Microsoft.AspNetCore.Http;
using Repositories.Entities;
using Repositories.Models.OrderModels;
using Repositories.Models.PaymentModels;
using Services.Models.ResponseModels;

namespace Services.Interfaces
{
    public interface ICartService
    {
        Task<ResponseDataModel<Cart>> Create(Guid accountId);
        Task<ResponseModel> ClearCart(Guid cartId);
    }
}
