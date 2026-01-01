using LogisticsManagementSystem.DTOs.ShipmentDTOs;
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
        private readonly IUserManagement _userManagement;
        private readonly IShipmentMethodService _shipmentMethodService;

        public ShipmentController(
            IShipmentService shipmentService,
            IUserManagement userManagement,
            IShipmentMethodService shipmentMethodService
        )
        {
            _shipmentService = shipmentService;
            _userManagement = userManagement;
            _shipmentMethodService = shipmentMethodService;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var shipemnt = await _shipmentService.GetByIdAsync(id);

                if (shipemnt == null)
                {
                    return NotFound(new { Message = "shipemnt not found." });
                }

                var shipmentDTO = new ShipmentDTO
                {
                    ShipmentId = shipemnt.ShipmentId,
                    ShipperName = shipemnt.ShipperName,
                    ReceiverName = shipemnt.ReceiverName,
                    CreatedAt = shipemnt.CreatedAt,
                    Status = shipemnt.Status!,
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

        [HttpGet("tracking/{trackingNumber}")]
        public async Task<IActionResult> GetByTrackingNumber(string trackingNumber)
        {
            try
            {
                var shipemnt = await _shipmentService.GetByTrackingNumber(trackingNumber);

                if (shipemnt == null)
                {
                    return NotFound(new { Message = "shipemnt not found." });
                }

                var shipmentDTO = new ShipmentDTO
                {
                    ShipmentId = shipemnt.ShipmentId,
                    ShipperName = shipemnt.ShipperName,
                    ReceiverName = shipemnt.ReceiverName,
                    CreatedAt = shipemnt.CreatedAt,
                    Status = shipemnt.Status!,
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
        public async Task<IActionResult> Create([FromBody] CreateShipmentDto createShipmentDto)
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

                var user = await _userManagement.GetUserByEmail(username);
                if (user == null)
                {
                    return Unauthorized("Customer not found.");
                }

                var shipment = await _shipmentService.CreateShipmentAsync(
                    createShipmentDto,
                    user.Id
                );

                return CreatedAtAction(nameof(GetById), new { id = shipment.ShipmentId }, shipment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(
                    500,
                    new { Message = "An error occurred while creating the shipment." }
                );
            }
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateShipmentDto updateShipmentDto
        )
        {
            if (updateShipmentDto == null)
            {
                return BadRequest(new { Message = "Shipment data cannot be null." });
            }

            try
            {
                await _shipmentService.UpdateShipmentAsync(id, updateShipmentDto);
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

        [Authorize]
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

                var shipmentMethod = await _shipmentMethodService.GetByIdAsync(
                    shipment.ShipmentMethodId
                );

                if (shipmentMethod == null)
                {
                    return NotFound("Shipment method not found.");
                }

                var shipmentMethodCost = await _shipmentMethodService.GetShipmentMethodCostAsync(
                    shipment.ShipmentMethodId
                );

                var totalCost = await _shipmentService.GetTotalCost(
                    shipment.Quantity,
                    shipment.Weight,
                    shipmentMethodCost
                );

                return Ok(new { TotalCost = totalCost });
            }
            catch (Exception)
            {
                return StatusCode(500, $"An error occurred while calculating the shipment rate.");
            }
        }
    }
}
