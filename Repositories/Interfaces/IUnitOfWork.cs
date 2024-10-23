namespace Repositories.Interfaces
{
	public interface IUnitOfWork
	{
		AppDbContext DbContext { get; }
		IAccountRepository AccountRepository { get; }
		IProductRepository ProductRepository { get; }
		IProductSizeRepository ProductSizeRepository { get; }
        ICartRepository CartRepository { get; }
		ICartItemRepository CartItemRepository { get; }
		IOrderRepository OrderRepository { get; }
		IPaymentRepository PaymentRepository { get; }
        IBrandRepository BrandRepository { get; }
        ICategoryRepository CategoryRepository { get; }
		ISizeRepository SizeRepository { get; }
		IFeedBackRepository FeedBackRepository { get; }
        public Task<int> SaveChangeAsync();
	}
}
