namespace Repositories.Interfaces
{
	public interface IUnitOfWork
	{
		AppDbContext DbContext { get; }
		IAccountRepository AccountRepository { get; }
		IProductRepository ProductRepository { get; }
		ICartRepository CartRepository { get; }
		ICartItemRepository CartItemRepository { get; }

		public Task<int> SaveChangeAsync();
	}
}
