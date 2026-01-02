using LogisticsManagementSystem.Constants;
using LogisticsManagementSystem.DTOs.PaymentDTOs;
using LogisticsManagementSystem.Models;
using LogisticsManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;
        private readonly IPaymentService _paymentService;
        private readonly IStripePaymentService _stripePaymentService;
        private readonly IPricingService _pricingService;

        public PaymentController(
            IShipmentService shipmentService,
            IPaymentService paymentService,
            IStripePaymentService stripePaymentService,
            IPricingService pricingService
        )
        {
            _shipmentService = shipmentService;
            _paymentService = paymentService;
            _stripePaymentService = stripePaymentService;
            _pricingService = pricingService;
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<PaymentInitiationResponse>> InitiateCheckout(
            [FromBody] InitiatePaymentDto request
        )
        {
            var shipment = await _shipmentService.GetByIdAsync(request.ShipmentId);
            if (shipment == null)
            {
                return NotFound(new { Message = "Shipment not found." });
            }

            var totalAmount = _pricingService.CalculateShipmentTotal(shipment);

            var newPayment = new Payment
            {
                ShipemntId = shipment.ShipmentId,
                Amount = totalAmount,
                Status = PaymentStatus.Pending,
                CreatedAt = DateTime.UtcNow,
            };

            var createdPayment = await _paymentService.CreatePaymentAsync(newPayment);

            shipment.PaymentId = createdPayment.PaymentId;
            await _shipmentService.Update(shipment);

            var origin = $"{Request.Scheme}://{Request.Host}";
            var checkoutUrl = await _stripePaymentService.CreateCheckoutSessionAsync(
                createdPayment,
                shipment,
                origin
            );

            return Ok(
                new PaymentInitiationResponse
                {
                    PaymentId = createdPayment.PaymentId,
                    Amount = createdPayment.Amount,
                    CheckoutUrl = checkoutUrl,
                }
            );
        }
    }
}
