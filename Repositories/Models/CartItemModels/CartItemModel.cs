namespace Repositories.Models.CartItemModels
{
    public class CartItemModel
    {
        public Guid Id { get; set; }
        public Guid CartID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
