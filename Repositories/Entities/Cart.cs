using Repositories.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    [Table("Cart")]
    public class Cart : BaseEntity
    {
        public Guid AccountID { get; set; }
        public decimal TotalPrice { get; set; }
        public Account Account { get; set; } = null!;
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
