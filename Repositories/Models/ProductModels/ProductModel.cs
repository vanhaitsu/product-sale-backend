namespace Repositories.Models.ProductModels
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string BriefDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
    }
}
