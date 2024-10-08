using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = null!;
        public string BriefDescription { get; set; } = null!;
        public  string FullDescription { get; set; } = null!;
        public string TechnicalSpecifications { get; set; } = null!;
        public int StockQuantity { get; set; } 
        public decimal Price { get; set; }
        /*public string ImageURL { get; set; } = null!;*/
        public Guid CategoryID { get; set; }
        public Category Category { get; set; } = null!;
        public Guid BrandID { get; set; }
        public Brand Brand { get; set; } = null!;
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public ICollection<FeedBack> FeedBacks { get; set; } = new List<FeedBack>();
    }
}
