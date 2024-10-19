using Repositories.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public class OrderCartItem : BaseEntity
    {
        public Guid OrderID { get; set; } 
        public Order Order { get; set; } = null!;
        public Guid ProductSizeID { get; set; }
        public ProductSize ProductSize { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Processing;
    }
}
