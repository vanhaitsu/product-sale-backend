﻿using AutoMapper;
using Repositories.Interfaces;
using Repositories.Models.ProductModels;
using Services.Common;
using Services.Interfaces;
using Services.Models.ProductModels;
using Services.Models.ResponseModels;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Pagination<ProductModel>> GetAll(ProductFilterModel productFilterModel)
        {
            var productList = await _unitOfWork.ProductRepository.GetAllAsync(
                pageIndex: productFilterModel.PageIndex,
                pageSize: productFilterModel.PageSize,
                filter: x =>
                    x.IsDeleted == productFilterModel.IsDeleted &&
                    (productFilterModel.MinPrice == null || x.Price >= productFilterModel.MinPrice) &&
                    (productFilterModel.MaxPrice == null || x.Price <= productFilterModel.MaxPrice) &&
                    (productFilterModel.CategoryID == null || x.CategoryID == productFilterModel.CategoryID) &&
                    (productFilterModel.BrandId == null || x.BrandID == productFilterModel.BrandId) &&
                    (productFilterModel.Rating == null || x.FeedBacks.Any(x => x.Rating == productFilterModel.Rating)) &&
                    (string.IsNullOrEmpty(productFilterModel.Search) ||
                     x.ProductName.ToLower().Contains(productFilterModel.Search.ToLower())),
                orderBy: x =>
                {
                    switch (productFilterModel.Order.ToLower())
                    {
                        case "price":
                            return productFilterModel.OrderByDescending
                                ? x.OrderByDescending(i => i.Price)
                                : x.OrderBy(i => i.Price);
                        default:
                            return productFilterModel.OrderByDescending
                                ? x.OrderByDescending(i => i.CreationDate)
                                : x.OrderBy(i => i.CreationDate);
                    }
                },
                include: "Category,Brand,ProductImages,FeedBacks"
            );

            if (productList != null)
            {
                var productModelList = _mapper.Map<List<ProductModel>>(productList.Data);
                return new Pagination<ProductModel>(
                    productModelList,
                    productFilterModel.PageIndex,
                    productFilterModel.PageSize, productList.TotalCount
                );
            }
            return null;
        }

        public async Task<ResponseDataModel<ProductModel>> Get(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.Get(id);

            if (product == null)
            {
                return new ResponseDataModel<ProductModel>()
                {
                    Status = false,
                    Message = "Product not found"
                };
            }

            var productModel = _mapper.Map<ProductModel>(product);

            return new ResponseDataModel<ProductModel>()
            {
                Status = true,
                Message = "Get Product successfully",
                Data = productModel
            };
        }
    }
}
