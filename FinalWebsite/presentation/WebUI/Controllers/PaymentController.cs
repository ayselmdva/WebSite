using FinalWebsite.Data.Entities;
using JwtExample.Data.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace FinalWebsite.WebUI.Controllers
{

    namespace FinalWebsite.WebUI.Controllers
    {
        public class PaymentController : Controller
        {
            private readonly IConfiguration _configuration;
            private readonly AppDbContext _context;

            public PaymentController(IConfiguration configuration, AppDbContext context)
            {
                _configuration = configuration;
                StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
                _context = context;
            }


            [HttpGet]
            public IActionResult ProcessPayment()
            {

                return View();
            }

            [HttpPost]
            public IActionResult ProcessPayment(Cart cart)
            {

                /*var options = new ChargeCreateOptions
                {
                    Amount = 2000,
                    Currency = "usd", 
                    Description = "Film ödemesi",
                    Source = "tok_mastercard" 
                };

                var service = new ChargeService();
                var charge = service.Create(options);


                if (charge.Status == "succeeded")
                {
                    return RedirectToAction("index", "home");
                }
                else
                {
                   
                    return View();
                }*/

                return RedirectToAction("index", "home");
            }

        }
    }
}
