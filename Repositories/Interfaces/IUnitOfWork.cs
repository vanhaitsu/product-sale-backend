namespace Repositories.Interfaces
{
	public interface IUnitOfWork
	{
		AppDbContext DbContext { get; }
		IAccountRepository AccountRepository { get; }
		IProductRepository ProductRepository { get; }

		public Task<int> SaveChangeAsync();
	}
}
