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
        public Guid ProductID { get; set; }
        public Guid SizeId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public Cart Cart { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
