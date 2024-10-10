using Repositories.Models.CategoryModels;
using Services.Common;
using Services.Models.CategoryModels;

namespace Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Pagination<CategoryModel>> GetAll(CategoryFilterModel categoryFilterModel);
    }
}
