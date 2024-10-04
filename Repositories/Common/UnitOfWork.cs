using Repositories.Interfaces;

namespace Repositories.Common
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _dbContext;
		private readonly IAccountRepository _accountRepository;
        private readonly IProductRepository _productRepository;

        public UnitOfWork(AppDbContext dbContext, IAccountRepository accountRepository,
			IProductRepository productRepository)
		{
			_dbContext = dbContext;
			_accountRepository = accountRepository;
			_productRepository = productRepository;
		}

		public AppDbContext DbContext => _dbContext;
		public IAccountRepository AccountRepository => _accountRepository;
        public IProductRepository ProductRepository => _productRepository;

        public async Task<int> SaveChangeAsync()
		{
			return await _dbContext.SaveChangesAsync();
		}
	}
}
