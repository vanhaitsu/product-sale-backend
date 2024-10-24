using Repositories.Interfaces;

namespace Repositories.Common
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _dbContext;
		private readonly IAccountRepository _accountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductSizeRepository _productSizeRepository;
        private readonly ICartRepository _cartRepository;
		private readonly ICartItemRepository _cartItemRepository;
		private readonly IPaymentRepository _paymentRepository;
		private readonly IOrderRepository _orderRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IFeedBackRepository _feedBackRepository;

        public UnitOfWork(AppDbContext dbContext, IAccountRepository accountRepository,
			IProductRepository productRepository, 
			ICartRepository cartRepository, 
			ICartItemRepository cartItemRepository,
            IPaymentRepository paymentRepository,
            IOrderRepository orderRepository,
            IBrandRepository brandRepository,
            ICategoryRepository categoryRepository,
			ISizeRepository sizeRepository,
			IProductSizeRepository productSizeRepository,
			IFeedBackRepository feedBackRepository)
			
		{
			_dbContext = dbContext;
			_accountRepository = accountRepository;
			_productRepository = productRepository;
			_cartRepository = cartRepository;
			_cartItemRepository = cartItemRepository;
			_paymentRepository = paymentRepository;
			_orderRepository = orderRepository;
			_brandRepository = brandRepository;
			_categoryRepository = categoryRepository;
			_sizeRepository = sizeRepository;
			_productSizeRepository = productSizeRepository;
			_feedBackRepository = feedBackRepository;
		}

		public AppDbContext DbContext => _dbContext;
		public IAccountRepository AccountRepository => _accountRepository;
		public IFeedBackRepository FeedBackRepository => _feedBackRepository;
        public IProductRepository ProductRepository => _productRepository;
        public IProductSizeRepository ProductSizeRepository => _productSizeRepository;

        public ICartRepository CartRepository => _cartRepository;
		public ICartItemRepository CartItemRepository => _cartItemRepository;
		public IPaymentRepository PaymentRepository => _paymentRepository;
		public IOrderRepository OrderRepository => _orderRepository;
        public IBrandRepository BrandRepository => _brandRepository;
        public ICategoryRepository CategoryRepository => _categoryRepository;
        public ISizeRepository SizeRepository => _sizeRepository;

        public async Task<int> SaveChangeAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}
	}
}
