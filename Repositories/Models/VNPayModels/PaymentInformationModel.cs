using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Models.VNPayModels
{
    public class PaymentInformationModel
    {
        public string BookingID { get; set; }
        public string AccountID { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public double Amount { get; set; }
    }
}
