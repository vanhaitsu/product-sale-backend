using Repositories.Entities;

namespace Services.Models.ProductModels
{
    public class ProductImportModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string BriefDescription { get; set; } = null!;
        public string FullDescription { get; set; } = null!;
        public string TechnicalSpecifications { get; set; } = null!;
        public decimal Price { get; set; }
        public Guid CategoryID { get; set; }
        public Guid BrandID { get; set; }
        public List<Guid> ProductImagesId { get; set; }
    }
}
