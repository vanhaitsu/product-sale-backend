using AutoMapper;
using Microsoft.AspNetCore.Http;
using Repositories.Entities;
using Repositories.Enums;
using Repositories.Interfaces;
using Repositories.Models.OrderModels;
using Repositories.Models.PaymentModels;
using Repositories.Models.VNPayModels;
using Services.Interfaces;
using Services.Models.ResponseModels;

namespace Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPaymentGatewayService _paymentGatewayService;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper, IPaymentGatewayService paymentGatewayService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _paymentGatewayService = paymentGatewayService;
        }
        public async Task<ResponseModel> VNPayMethod(OrderModel orderModel, HttpContext context)
        {
            var result = new ResponseModel();
            var cart = await _unitOfWork.CartRepository.GetAsync(orderModel.CartID, "Account, CartItems");
            if (cart == null)
            {
                return new ResponseModel { Message = "Cart cannot be found.", Status = false };
            }
            if (cart.CartItems.Count == 0)
            {
                return new ResponseModel { Message = "Must have at least one product to checkout.", Status = false };
            }
            var user = await _unitOfWork.AccountRepository.GetAccountById(orderModel.AccountID);
            if (user == null)
            {
                return new ResponseModel { Message = "User cannot be found.", Status = false };
            }
            var newOrder = CreateOrder(cart, user, orderModel);
            await _unitOfWork.OrderRepository.AddAsync(newOrder);
            int check = await _unitOfWork.SaveChangeAsync();
            if (check > 0)
            {
                var payment = new PaymentInformationModel
                {
                    AccountID = newOrder.AccountID.ToString(),
                    Amount = (double)newOrder.Payment.Amount,
                    CustomerName = cart.Account.FirstName + cart.Account.LastName,
                    BookingID = cart.Id.ToString(),
                };
                result.Message = "Payment successfully.";
                result.Status = true;
                result.Data = await _paymentGatewayService.CreatePaymentUrlVnpay(payment, context);
                return result;

            }
            return new ResponseDataModel<PaymentModel>()
            {
                Status = true,
                Message = "Payment fail.",
            };

        }
        private Order CreateOrder(Cart cart, Account user, OrderModel orderModel)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                CartItemID = cart.Id,
                AccountID = user.Id,
                BillingAddress = orderModel.BillingAddress,
                PaymentMethod = PaymentMethod.VNPay,
                Payment = new Payment
                {
                    Id = Guid.NewGuid(),
                    Amount = cart.TotalPrice,
                }
            };
        }
    }
}
