using Repositories.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public class Cart : BaseEntity
    {
        public Guid AccountID { get; set; }
        public decimal TotalPrice { get; set; }
        public CartStatus Status { get; set; } = CartStatus.Active;
        public Account Account { get; set; } = null!;
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
        public Order? Order { get; set; }
    }
}
