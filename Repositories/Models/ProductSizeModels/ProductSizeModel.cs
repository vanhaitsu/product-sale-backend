using Repositories.Entities;

namespace Repositories.Models.ProductSizeModels
{
    public class ProductSizeModel
    {
        public Guid ProductId { get; set; }
        public Guid SizeId { get; set; }
        public string SizeName { get; set; }
        public int StockQuantity { get; set; }
    }
}
