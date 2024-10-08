﻿using AutoMapper;
using Repositories.Entities;
using Repositories.Interfaces;
using Repositories.Models.CartItemModels;
using Services.Common;
using Services.Interfaces;
using Services.Models.CartItemModels;
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
            cartItem.Price = product.Price;

            await _unitOfWork.CartItemRepository.AddAsync(cartItem);

            cart.TotalPrice += product.Price * cartItem.Quantity;
            _unitOfWork.CartRepository.Update(cart);

            int check = await _unitOfWork.SaveChangeAsync();
            return check > 0
               ? new ResponseModel { Message = "Add to cart successfully.", Status = true }
               : new ResponseModel { Message = "Add to cart fail.", Status = false };
        }
        public async Task<Pagination<CartItemModel>> GetCartItemOverview(CartItemFilterModel cartItemFilterModel)
        {
            var cart = await _unitOfWork.CartRepository.GetByAccount(cartItemFilterModel.AccountID);

            if (cart == null)
            {
                return null; 
            }

            var cartId = cart.Id;
            var cartItemsResult = await _unitOfWork.CartItemRepository.GetAllAsync(
                filter: _ => _.CartID == cartId,
                include: "Product, Cart", 
                pageIndex: cartItemFilterModel.PageIndex,
                pageSize: cartItemFilterModel.PageSize
            );

            if (cartItemsResult != null)
            {
                var cartItemModelList = cartItemsResult.Data.Select(_ => new CartItemModel
                {
                    Id = _.Id,
                    CartID = _.CartID,
                    ProductID = _.ProductID,
                    ProductName = _.Product.ProductName,
                    ImageUrl = _.Product.ProductImages.FirstOrDefault()?.ImgUrl ?? string.Empty, 
                    PricePerItem = _.Price,
                    Quantity = _.Quantity,
                    TotalPrice = _.Price * _.Quantity,
                }).ToList();

                return new Pagination<CartItemModel>(
                    cartItemModelList,
                    cartItemFilterModel.PageIndex,
                    cartItemFilterModel.PageSize,
                    cartItemsResult.TotalCount
                );
            }

            return null; 
        }
        public async Task<ResponseModel> RemoveProductFromCartItem(Guid cartItemId)
        {
            var cartItem = await _unitOfWork.CartItemRepository.GetCartItem(cartItemId);
            if (cartItem == null)
            {
                return new ResponseModel { Message = "Cart item not found.", Status = false };
            }
            _unitOfWork.CartItemRepository.HardDelete(cartItem);
            var result = await _unitOfWork.SaveChangeAsync();
            if (result > 0)
            {
                var remainingCartItems = await _unitOfWork.CartItemRepository.GetAllAsync(_ => _.CartID == cartItem.CartID);
                var cart = await _unitOfWork.CartRepository.GetById(cartItem.CartID);
                if (remainingCartItems.Data.Count == 0)
                {
                    if (cart != null)
                    {
                        cart.TotalPrice = 0; 
                    }
                }
                else
                {
                    cart.TotalPrice = remainingCartItems.Data.Sum(_ => _.Price * _.Quantity);
                }
                _unitOfWork.CartRepository.Update(cart); 
                await _unitOfWork.SaveChangeAsync();
                return new ResponseModel { Message = "Cart item removed successfully.", Status = true };
            }
            return new ResponseModel { Message = "Failed to remove cart item.", Status = false };
        }
        public async Task<ResponseModel> AdjustCartItemQuantity(Guid cartItemId, int quantity)
        {
            var cartItem = await _unitOfWork.CartItemRepository.GetCartItem(cartItemId);

            if (cartItem == null )
            {
                return new ResponseModel { Message = "Cart item not found.", Status = false };
            }
            cartItem.Quantity = quantity;
            var cart = await _unitOfWork.CartRepository.GetById(cartItem.CartID);
            if (cart != null)
            {
                if (cartItem.Quantity <= 0)
                {
                    _unitOfWork.CartItemRepository.HardDelete(cartItem);
                }
                else
                {
                    _unitOfWork.CartItemRepository.Update(cartItem);
                }

                var cartItems = await _unitOfWork.CartItemRepository.GetAllAsync(_ => _.CartID == cart.Id);
                cart.TotalPrice = cartItems.Data.Sum(_ => _.Price * _.Quantity);
                _unitOfWork.CartRepository.Update(cart);
            }
            var result = await _unitOfWork.SaveChangeAsync();

            return result > 0
                ? new ResponseModel { Message = "Cart item updated successfully.", Status = true }
                : new ResponseModel { Message = "Failed to update cart item.", Status = false };
        }



    }
}
