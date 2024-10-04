using AutoMapper;
using Repositories.Entities;
using Repositories.Models.AccountModels;
using Repositories.Models.FeedbackModels;
using Repositories.Models.ProductImageModels;
using Repositories.Models.ProductModels;
using Services.Models.AccountModels;
using Services.Models.CartModels;
using Services.Models.CommonModels;

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
            CreateMap<Product, ProductModel>().ReverseMap();

			//ProductImage
            CreateMap<ProductImage, ProductImageModel>();

			//Feedback
            CreateMap<FeedBack, FeedbackModel>();

            //CartItem
            CreateMap<CartItemCreateModel, CartItem>();
        }
	}
}
