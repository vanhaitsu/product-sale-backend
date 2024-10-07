using Microsoft.AspNetCore.Http;
using Repositories.Models.VNPayModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPaymentGatewayService
    {
        Task<string> CreatePaymentUrlVnpay(PaymentInformationModel request, HttpContext httpContext);
    }
}
