using Repositories.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public class Order : BaseEntity
    {
        public Guid CartID { get; set; }
        public Guid AccountID { get; set; }
        public string PaymentMethod { get; set; } = null!;  
        public string BillingAddress { get; set; } = null!;
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Processing;  
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public Cart Cart { get; set; } = null!;
        public Account Account { get; set; } = null!;
        public Payment? Payment { get; set; }
    }
}
