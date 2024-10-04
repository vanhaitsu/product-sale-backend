using AutoMapper;
using Repositories.Entities;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Models.ResponseModels;

namespace Services.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseDataModel<Cart>> Create(Guid accountId)
        {
            var account = await _unitOfWork.AccountRepository.GetAccountById(accountId);
            if (account == null)
            {
                return new ResponseDataModel<Cart>()
                {
                    Message = "Account not found",
                    Status = false
                };
            }

            Cart cart = new()
            {
                AccountID = account.Id,
                TotalPrice = 0
            };

            await _unitOfWork.CartRepository.AddAsync(cart);
            int check = await _unitOfWork.SaveChangeAsync();

            return new ResponseDataModel<Cart>()
            {
                Message = "Create cart successfully!",
                Status = true,
                Data = cart
            };
        }
    }
}
