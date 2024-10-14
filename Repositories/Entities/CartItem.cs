using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    [Table("CartItem")]
    public class CartItem : BaseEntity
    {
        public Guid CartID { get; set; }
        public Guid ProductSizeID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Cart Cart { get; set; } = null!;
        public ProductSize ProductSize { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
