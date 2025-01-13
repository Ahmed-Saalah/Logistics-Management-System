using LogisticsManagementSystem.DTO.PaymentDTOs;
using LogisticsManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using System;

namespace LogisticsManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly StripeOptions _stripeOptions;
        private readonly Services.CustomerService _customerService;
        public PaymentController(IOptionsSnapshot<StripeOptions> stripeOptions, Services.CustomerService customerService)
        {
            _stripeOptions = stripeOptions.Value;
            _customerService = customerService;
        }

        [HttpPost]

        public async Task<IActionResult> Pay(PaymentRequestDTO paymentRequestDTO)
        {
            var origin = $"{Request.Scheme}://{Request.Host}";

            StripeConfiguration.ApiKey = _stripeOptions.SecretKey;

            var stripeSessionService = new SessionService();

            var stripeCheckOutSession = await stripeSessionService.CreateAsync(
                new SessionCreateOptions
                {
                    Mode = "payment",
                    ClientReferenceId = paymentRequestDTO.ShipmentId.ToString(),
                    SuccessUrl = $"{origin}/confirmation.html",
                    CancelUrl = $"{origin}/index.html",
                    LineItems = new()
                    {
                        new()
                        {
                            PriceData = new()
                            {
                                Currency = "USD",
                                ProductData = new()
                                {
                                    Name = "Shipment"
                                },
                                UnitAmountDecimal = paymentRequestDTO.Amount * 100
                            },
                            Quantity = 1
                        }
                    }
                });

            return Ok(new { redirectUrl = stripeCheckOutSession.Url });
        }

    }
}
