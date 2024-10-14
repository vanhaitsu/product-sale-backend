namespace Services.Models.CartModels
{
    public class CartItemCreateModel
    {
        public Guid AccountID { get; set; }
        public Guid ProductID { get; set; }
        public Guid SizeId { get; set; }
        public int Quantity { get; set; }
    }
}
