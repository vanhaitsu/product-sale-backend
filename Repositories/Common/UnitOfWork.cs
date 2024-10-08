using Repositories.Interfaces;

namespace Repositories.Common
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _dbContext;
		private readonly IAccountRepository _accountRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
		private readonly ICartItemRepository _cartItemRepository;
		private readonly IPaymentRepository _paymentRepository;
		private readonly IOrderRepository _orderRepository;

        public UnitOfWork(AppDbContext dbContext, IAccountRepository accountRepository,
			IProductRepository productRepository, 
			ICartRepository cartRepository, 
			ICartItemRepository cartItemRepository,
            IPaymentRepository paymentRepository,
            IOrderRepository orderRepository)
		{
			_dbContext = dbContext;
			_accountRepository = accountRepository;
			_productRepository = productRepository;
			_cartRepository = cartRepository;
			_cartItemRepository = cartItemRepository;
			_paymentRepository = paymentRepository;
			_orderRepository = orderRepository;
		}

		public AppDbContext DbContext => _dbContext;
		public IAccountRepository AccountRepository => _accountRepository;
        public IProductRepository ProductRepository => _productRepository;
		public ICartRepository CartRepository => _cartRepository;
		public ICartItemRepository CartItemRepository => _cartItemRepository;
		public IPaymentRepository PaymentRepository => _paymentRepository;
		public IOrderRepository OrderRepository => _orderRepository;

        public async Task<int> SaveChangeAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}
	}
}
