using AutoMapper;
using Repositories.Entities;
using Repositories.Models.AccountModels;
using Repositories.Models.BrandModels;
using Repositories.Models.CategoryModels;
using Repositories.Models.FeedbackModels;
using Repositories.Models.ProductImageModels;
using Repositories.Models.ProductModels;
using Repositories.Models.ProductSizeModels;
using Repositories.Models.SizeModels;
using Services.Models.AccountModels;
using Services.Models.CartModels;
using Services.Models.CommonModels;
using Services.Models.ProductModels;

namespace Services.Common
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			//Account
			CreateMap<AccountRegisterModel, Account>();
			CreateMap<GoogleUserInformationModel, Account>();
			CreateMap<AccountModel, Account>().ReverseMap();

            //Product
            CreateMap<ProductModel, Product>().ReverseMap();
            CreateMap<Product, ProductModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName))
                .ReverseMap();
            CreateMap<ProductImportModel, Product>().ReverseMap();

            //ProductImage
            CreateMap<ProductImage, ProductImageModel>();

			//Feedback
            CreateMap<FeedBack, FeedbackModel>();

            //CartItem
            CreateMap<CartItemCreateModel, CartItem>();

            //Size
            CreateMap<Size, SizeModel>();

            //ProductSize
            CreateMap<ProductSize, ProductSizeModel>()
                .ForMember(dest => dest.SizeName, opt => opt.MapFrom(src => src.Size.Name))
                .ReverseMap();

            //Brand
            CreateMap<Brand, BrandModel>().ReverseMap();

            //Category
            CreateMap<Category, CategoryModel>().ReverseMap();
        }
	}
}
