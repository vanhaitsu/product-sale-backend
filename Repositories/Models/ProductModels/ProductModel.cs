using Repositories.Entities;
using Repositories.Models.FeedbackModels;
using Repositories.Models.ProductImageModels;
using Repositories.Models.SizeModels;

namespace Repositories.Models.ProductModels
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string BriefDescription { get; set; } = null!;
        public string FullDescription { get; set; } = null!;
        public string TechnicalSpecifications { get; set; } = null!;
        public decimal Price { get; set; }
        public Guid CategoryID { get; set; }
        public Guid BrandID { get; set; }
        public List<ProductImageModel>? ProductImages { get; set; }
        public List<FeedbackModel>? Feedbacks { get; set; }
        public List<SizeModel>? SizeModels { get; set; }
    }
}
