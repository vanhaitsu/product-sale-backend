using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories.Entities
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = null!;
        public string BriefDescription { get; set; } = null!;
        public  string FullDescription { get; set; } = null!;
        public string TechnicalSpecifications { get; set; } = null!;
        public decimal Price { get; set; }
        /*public string ImageURL { get; set; } = null!;*/
        public Guid CategoryID { get; set; }
        public Category Category { get; set; } = null!;
        public Guid BrandID { get; set; }
        public Brand Brand { get; set; } = null!;
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public ICollection<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();
        public ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
    }
}
