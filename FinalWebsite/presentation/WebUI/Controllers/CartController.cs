using FinalWebsite.Data.Entities;
using FinalWebsite.WebUI.View_Models;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using WebApp.Repositories.Abstract;

namespace FinalWebsite.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ShoppingCartVM ShoppingCartVM { get; set; }

        [HttpPost]
        public IActionResult Index()
        {
            var domain = "https://localhost:44300/";
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + $"cart/OderConfirmation?id={ShoppingCartVM.OderHeader.Id}",
                CancelUrl = domain + $"cart/index"
            };


            foreach (var item in ShoppingCartVM.listCart) 
            {
                var sessionLineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)(item.Price * 100),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Movie.Name,
                        },
                    },
                    Quantity = item.Count,
                };
                options.LineItems.Add(sessionLineItem);
            }

            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);

        }

        /*public async Task<IActionResult>OderConfirmation(int id)
        {
            OderHeader oderHeader=await _unitOfWork.OderHeaderRepository.GetAsync(x=>x.Id == id);
        }*/
    }
}
