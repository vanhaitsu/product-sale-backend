namespace Repositories.Entities
{
    public class ProductSize : BaseEntity
    {
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public Guid SizeId { get; set; }      
        public Size Size { get; set; }
        public int StockQuantity { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<OrderCartItem> OrderCartItems { get; set; } = new List<OrderCartItem>();

    }
}
