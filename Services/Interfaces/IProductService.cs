
using Repositories.Models.ProductModels;
using Services.Common;
using Services.Models.ProductModels;
using Services.Models.ResponseModels;

namespace Services.Interfaces
{
    public interface IProductService
    {
        Task<Pagination<ProductModel>> GetAll(ProductFilterModel productFilterModel);
        Task<ResponseDataModel<ProductModel>> Get(Guid id);
    }
}
