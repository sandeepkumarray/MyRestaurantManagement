using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManagement.Services
{
    public class PaymentGateway : IPaymentGateway
    {
        public bool Status = false;
        public Guid PaymentID { get; set; }
        public void MakePayment(string Name, long CardNumber, int ExpiryMonth, int ExpiryYear, string CVV)
        {
            PaymentID = Guid.NewGuid();
            Status = true;
        }
    }
}
