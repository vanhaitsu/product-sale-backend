
using Repositories.Models.ProductModels;
using Services.Common;
using Services.Models.ProductModels;

namespace Services.Interfaces
{
    public interface IProductService
    {
        Task<Pagination<ProductModel>> GetAll(ProductFilterModel productFilterModel);
    }
}
