using Repositories.Entities;
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
        public Guid AccountID { get; set; }
        public string BillingAddress { get; set; } 
        public List<OrderCartItemModel> OrderCartItemModels { get; set; }
    }
    public class OrderCartItemModel
    {
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
