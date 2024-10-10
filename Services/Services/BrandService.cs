using AutoMapper;
using Repositories.Interfaces;
using Repositories.Models.BrandModels;
using Services.Common;
using Services.Interfaces;
using Services.Models.BrandModels;

namespace Services.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Pagination<BrandModel>> GetAll(BrandFilterModel brandFilterModel)
        {
            var brandList = await _unitOfWork.BrandRepository.GetAllAsync(
                pageIndex: brandFilterModel.PageIndex,
                pageSize: brandFilterModel.PageSize,
                filter: x =>
                    (string.IsNullOrEmpty(brandFilterModel.Search) ||
                     x.BrandName.ToLower().Contains(brandFilterModel.Search.ToLower())),
                orderBy: x =>
                {
                    return brandFilterModel.OrderByDescending
                        ? x.OrderByDescending(i => i.BrandName)
                        : x.OrderBy(i => i.BrandName);
                }
            );

            if (brandList != null)
            {
                var brandModelList = _mapper.Map<List<BrandModel>>(brandList.Data);
                return new Pagination<BrandModel>(
                    brandModelList,
                    brandFilterModel.PageIndex,
                    brandFilterModel.PageSize, brandList.TotalCount
                );
            }
            return null;
        }
    }
}
