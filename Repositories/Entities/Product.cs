using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; } = null!;
        public string BriefDescription { get; set; } = null!;
        public  string FullDescription { get; set; } = null!;
        public string TechnicalSpecifications { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageURL { get; set; } = null!;
        public Guid CategoryID { get; set; }
        public Category Category { get; set; } = null!;
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
