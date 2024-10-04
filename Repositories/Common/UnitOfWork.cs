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

        public UnitOfWork(AppDbContext dbContext, IAccountRepository accountRepository,
			IProductRepository productRepository, 
			ICartRepository cartRepository, 
			ICartItemRepository cartItemRepository)
		{
			_dbContext = dbContext;
			_accountRepository = accountRepository;
			_productRepository = productRepository;
			_cartRepository = cartRepository;
			_cartItemRepository = cartItemRepository;
		}

		public AppDbContext DbContext => _dbContext;
		public IAccountRepository AccountRepository => _accountRepository;
        public IProductRepository ProductRepository => _productRepository;
		public ICartRepository CartRepository => _cartRepository;
		public ICartItemRepository CartItemRepository => _cartItemRepository;

        public async Task<int> SaveChangeAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}
	}
}
