using AutoMapper;
using Microsoft.Identity.Client;
using Repositories.Entities;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Models.CartModels;
using Services.Models.ResponseModels;

namespace Services.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;

        public CartItemService(IUnitOfWork unitOfWork, IMapper mapper,
            ICartService cartService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cartService = cartService;
        }

        public async Task<ResponseModel> Create(CartItemCreateModel cartItemCreateModel)
        {
            var account = await _unitOfWork.AccountRepository.GetAccountById(cartItemCreateModel.AccountID);
            if (account == null)
            {
                return new ResponseModel()
                {
                    Message = "Account not found",
                    Status = false
                };
            }

            var product = await _unitOfWork.ProductRepository.GetAsync(cartItemCreateModel.ProductID);
            if (product == null)
            {
                return new ResponseModel()
                {
                    Message = "Product not found",
                    Status = false
                };
            }

            var cart = await _unitOfWork.CartRepository.GetByAccount(account.Id);
            if (cart == null)
            {
                var response = await _cartService.Create(account.Id);
                cart = response.Data;
            }

            CartItem cartItem = _mapper.Map<CartItem>(cartItemCreateModel);
            cartItem.CartID = cart.Id;
            cartItem.Price += product.Price * cartItemCreateModel.Quantity;

            await _unitOfWork.CartItemRepository.AddAsync(cartItem);

            cart.TotalPrice += product.Price * cartItem.Quantity;

            int check = await _unitOfWork.SaveChangeAsync();

            return new ResponseModel()
            {
                Message = "Add to cart successfully!",
                Status = true
            };
        }
    }
}
