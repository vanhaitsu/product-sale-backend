namespace Repositories.Entities
{
    public class ProductSize : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid SizeId { get; set; }
        public Size Size { get; set; }
        public int StockQuantity { get; set; }
    }
}
