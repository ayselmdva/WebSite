using FinalWebsite.Business.Services.Abstract;
using FinalWebsite.Data.Entities;
using Microsoft.Extensions.Options;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWebsite.Business.Services.Concrete
{
    /*  public class PaymmentManage : IPaymentService
      {
          private readonly StripeOptions _stripeOptions;

          public PaymmentManage(IOptions<StripeOptions> stripeOptions)
          {
              _stripeOptions = stripeOptions.Value;
          }

          public bool MakePayment(decimal amount, string cardNumber, string expirationMonth, string expirationYear, string cvv)
          {
              throw new NotImplementedException();
          }

          public PaymentIntent ProcessPayment(int amount, string currency)
          {
              StripeConfiguration.ApiKey = _stripeOptions.SecretKey;

              var options = new PaymentIntentCreateOptions
              {
                  Amount = amount,
                  Currency = currency,
                  PaymentMethodTypes = new List<string> { "card" }
              };

              var service = new PaymentIntentService();
              var paymentIntent = service.Create(options);

              return paymentIntent;
          }
      }*/

    using Stripe;

    public class PaymentManage:IPaymentService
    {
        private readonly StripeOptions _stripeOptions;

        public PaymentManage(IOptions<StripeOptions> stripeOptions)
        {
            _stripeOptions = stripeOptions.Value;
        }

        public PaymentIntent ProcessPayment(decimal amount, string currency)
        {
            StripeConfiguration.ApiKey = _stripeOptions.SecretKey;

            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)amount,
                Currency = currency,
                PaymentMethodTypes = new List<string> { "card" }
            };

            var service = new PaymentIntentService();
            var paymentIntent = service.Create(options);

            return paymentIntent;
        }
    }

}
