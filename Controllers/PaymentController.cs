using LogisticsManagementSystem.Models;
using LogisticsManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace LogisticsManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly StripeOptions _stripeOptions;
        private readonly IShipmentService _shipmentService;
        private readonly IPaymentService _paymentService;

        public PaymentController(
            IOptionsSnapshot<StripeOptions> stripeOptions,
            IShipmentService shipmentService,
            IPaymentService paymentService
        )
        {
            _stripeOptions = stripeOptions.Value;
            _shipmentService = shipmentService;
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] Payment payment)
        {
            try
            {
                if (!payment.ShipemntId.HasValue)
                {
                    return BadRequest(new { Message = "ShipmentId is required." });
                }

                var shipment = await _shipmentService.GetByIdAsync(payment.ShipemntId.Value);

                if (shipment == null)
                {
                    return NotFound(new { Message = "Shipment not found." });
                }

                payment.Amount =
                    (shipment.Quantity * shipment.Weight) + shipment.ShipmentMethod.Cost;

                var createdPayment = await _paymentService.CreatePaymentAsync(payment);

                shipment.PaymentId = createdPayment.PaymentId;

                await _shipmentService.Update(shipment);

                // Prepare Stripe Session
                var origin = $"{Request.Scheme}://{Request.Host}";

                StripeConfiguration.ApiKey = _stripeOptions.SecretKey;

                var stripeSessionService = new SessionService();

                var stripeCheckOutSession = await stripeSessionService.CreateAsync(
                    new SessionCreateOptions
                    {
                        Mode = "payment",
                        ClientReferenceId = shipment.ShipmentId.ToString(),
                        SuccessUrl = $"{origin}/confirmation.html",
                        CancelUrl = $"{origin}/index.html",
                        LineItems = new()
                        {
                            new()
                            {
                                PriceData = new()
                                {
                                    Currency = "USD",
                                    ProductData = new() { Name = "Shipment" },
                                    UnitAmountDecimal = payment.Amount * 100,
                                },
                                Quantity = 1,
                            },
                        },
                    }
                );

                return Ok(
                    new
                    {
                        Message = "Payment successfully created.",
                        PaymentId = createdPayment.PaymentId,
                        TotalAmount = payment.Amount,
                        CheckoutUrl = stripeCheckOutSession.Url,
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred.", Error = ex.Message });
            }
        }
    }
}
