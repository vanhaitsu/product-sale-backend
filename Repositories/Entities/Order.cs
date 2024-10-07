using Repositories.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    [Table("Order")]
    public class Order : BaseEntity
    {
        public Guid CartItemID { get; set; }
        public Guid AccountID { get; set; }
        public PaymentMethod PaymentMethod { get; set; } 
        public string BillingAddress { get; set; } = null!;
        public OrderStatus Status { get; set; } = OrderStatus.Processing;  
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public CartItem CartItem { get; set; } = null!;
        public Account Account { get; set; } = null!;
        public Payment? Payment { get; set; }
    }
}
