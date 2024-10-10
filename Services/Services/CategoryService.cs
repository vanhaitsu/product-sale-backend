using AutoMapper;
using Repositories.Interfaces;
using Repositories.Models.CategoryModels;
using Services.Common;
using Services.Interfaces;
using Services.Models.CategoryModels;

namespace Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Pagination<CategoryModel>> GetAll(CategoryFilterModel categoryFilterModel)
        {
            var categoryList = await _unitOfWork.CategoryRepository.GetAllAsync(
                pageIndex: categoryFilterModel.PageIndex,
                pageSize: categoryFilterModel.PageSize,
                filter: x =>
                    (string.IsNullOrEmpty(categoryFilterModel.Search) ||
                     x.CategoryName.ToLower().Contains(categoryFilterModel.Search.ToLower())),
                orderBy: x =>
                {
                    return categoryFilterModel.OrderByDescending
                        ? x.OrderByDescending(i => i.CategoryName)
                        : x.OrderBy(i => i.CategoryName);
                }
            );

            if (categoryList != null)
            {
                var categoryModelList = _mapper.Map<List<CategoryModel>>(categoryList.Data);
                return new Pagination<CategoryModel>(
                    categoryModelList,
                    categoryFilterModel.PageIndex,
                    categoryFilterModel.PageSize, categoryList.TotalCount
                );
            }
            return null;
        }
    }
}
