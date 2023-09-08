using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebsite.Business.Services.Abstract
{
    public interface IPaymentService
    {
        /* bool MakePayment(decimal amount, string cardNumber, string expirationMonth, string expirationYear, string cvv);*/
        PaymentIntent ProcessPayment(decimal amount, string currency);
    }
}
