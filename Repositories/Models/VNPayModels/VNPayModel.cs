using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models.VNPayModels
{
    public class VNPayModel
    {
        public string BookingDescription { get; set; }
        public string TransactionId { get; set; }
        public string BookingId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentId { get; set; }
        public bool Success { get; set; }
        public string Token { get; set; }
        public string VnPayResponseCode { get; set; }
        public string Amount { get; set; }
        public string PayDate { get; set; }
    }
}
