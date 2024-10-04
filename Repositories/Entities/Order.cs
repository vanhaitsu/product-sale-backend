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
        public Guid CartID { get; set; }
        public Guid AccountID { get; set; }
        public string PaymentMethod { get; set; } = null!;  
        public string BillingAddress { get; set; } = null!;
        public OrderStatus Status { get; set; } = OrderStatus.Processing;  
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Cart Cart { get; set; } = null!;
        public Account Account { get; set; } = null!;
        public Payment? Payment { get; set; }
    }
}
