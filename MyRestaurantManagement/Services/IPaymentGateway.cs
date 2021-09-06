using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRestaurantManagement.Services
{
    public interface IPaymentGateway
    {
        void MakePayment(string Name, long CardNumber, int ExpiryMonth, int ExpiryYear, string CVV);
    }
}
