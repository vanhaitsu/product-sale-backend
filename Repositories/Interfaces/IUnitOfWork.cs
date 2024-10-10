namespace Repositories.Interfaces
{
	public interface IUnitOfWork
	{
		AppDbContext DbContext { get; }
		IAccountRepository AccountRepository { get; }
		IProductRepository ProductRepository { get; }
		ICartRepository CartRepository { get; }
		ICartItemRepository CartItemRepository { get; }
		IOrderRepository OrderRepository { get; }
		IPaymentRepository PaymentRepository { get; }
        IBrandRepository BrandRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        public Task<int> SaveChangeAsync();
	}
}
