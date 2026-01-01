using LogisticsManagementSystem.DTOs.ShipmentDTOs;
using LogisticsManagementSystem.Services.Implementations;
using LogisticsManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;
        private readonly CustomerService _customerService;
        private readonly IShipmentMethodService _shipmentMethodService;

        public ShipmentController(
            IShipmentService shipmentService,
            CustomerService customerService,
            IShipmentMethodService shipmentMethodService
        )
        {
            _shipmentService = shipmentService;
            _customerService = customerService;
            _shipmentMethodService = shipmentMethodService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var shipemnt = await _shipmentService.GetByIdAsync(id);

                if (shipemnt == null)
                    return NotFound(new { Message = "shipemnt not found." });

                var shipmentDTO = new ShipmentDTO
                {
                    ShipmentId = shipemnt.ShipmentId,
                    ShipperName = shipemnt.ShipperName,
                    ReceiverName = shipemnt.ReceiverName,
                    CreatedAt = shipemnt.CreatedAt.Value,
                    Status = shipemnt.Status,
                };

                return Ok(shipmentDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        Message = "An error occurred while processing the request.",
                        Error = ex.Message,
                    }
                );
            }
        }

        [HttpGet("by-tracking/{trackingNumber}")]
        public async Task<IActionResult> GetByTrackingNumber(string trackingNumber)
        {
            try
            {
                var shipemnt = await _shipmentService.GetByTrackingNumber(trackingNumber);

                if (shipemnt == null)
                    return NotFound(new { Message = "shipemnt not found." });

                var shipmentDTO = new ShipmentDTO
                {
                    ShipmentId = shipemnt.ShipmentId,
                    ShipperName = shipemnt.ShipperName,
                    ReceiverName = shipemnt.ReceiverName,
                    CreatedAt = shipemnt.CreatedAt.Value,
                    Status = shipemnt.Status,
                };

                return Ok(shipmentDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        Message = "An error occurred while processing the request.",
                        Error = ex.Message,
                    }
                );
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateShipmentDto shipmentCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var username = User.Identity?.Name;
                if (string.IsNullOrEmpty(username))
                {
                    return Unauthorized("User is not authenticated.");
                }

                var customerId = await _customerService.GetCustomerIdByUsernameAsync(username);
                if (customerId == null)
                {
                    return Unauthorized("Customer not found.");
                }

                var shipment = await _shipmentService.CreateShipmentAsync(
                    shipmentCreateDTO,
                    customerId.Value
                );

                //return CreatedAtAction(nameof(GetById), new { id = shipment.ShipmentId }, shipment);
                return Ok(shipment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new { Message = "An error occurred while creating the shipment." }
                );
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateShipmentDto shipmentUpdateDTO
        )
        {
            if (shipmentUpdateDTO == null)
                return BadRequest(new { Message = "Shipment data cannot be null." });

            if (id != shipmentUpdateDTO.ShipmentId)
                return BadRequest(
                    new
                    {
                        Message = "Shipment ID in the URL does not match the Shipment ID in the request body.",
                    }
                );

            try
            {
                await _shipmentService.UpdateShipmentAsync(id, shipmentUpdateDTO);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        Message = "An error occurred while updating the shipment.",
                        Error = ex.Message,
                    }
                );
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _shipmentService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(
                    500,
                    new
                    {
                        Message = "An error occurred while deleting the shipment.",
                        Error = ex.Message,
                    }
                );
            }
        }

        /// <summary>
        /// Rate Calculator API
        /// inquire about shipping rate and provide customers with real time rates.
        /// </summary>

        [HttpPost("rateCalculator")]
        public async Task<IActionResult> RateCalculatorAsync(
            [FromBody] ShipmentWithRateDTO shipment
        )
        {
            try
            {
                if (shipment.Quantity <= 0 || shipment.Weight <= 0)
                {
                    return BadRequest("Invalid input parameters.");
                }

                var shipmentMethodCost = await _shipmentMethodService.GetShipmentMethodCostAsync(
                    shipment.ShipmentMethodId
                );
                if (shipmentMethodCost == 0)
                {
                    return NotFound("Shipment method not found.");
                }

                var totalCost = await _shipmentService.GetTotalCost(
                    shipment.Quantity,
                    shipment.Weight,
                    shipmentMethodCost
                );

                return Ok(new { totalCost });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
