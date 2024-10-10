using Repositories.Models.BrandModels;
using Services.Common;
using Services.Models.BrandModels;

namespace Services.Interfaces
{
    public interface IBrandService
    {
        Task<Pagination<BrandModel>> GetAll(BrandFilterModel brandFilterModel);
    }
}
