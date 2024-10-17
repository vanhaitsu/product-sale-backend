namespace Repositories.Models.CartItemModels
{
    public class CartItemModel
    {
        public Guid Id { get; set; }
        public Guid CartID { get; set; }
        public Guid ProductID { get; set; }
        public Guid SizeID { get; set; }
        public Guid ProductSizeID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string SizeName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal PricePerItem { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
