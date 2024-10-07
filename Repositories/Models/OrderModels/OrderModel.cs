using Repositories.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models.OrderModels
{
    public class OrderModel
    {
        public Guid CartID { get; set; }
        public Guid AccountID { get; set; }
        public string BillingAddress { get; set; } = null!;
    }
}
