using LogisticsManagementSystem.DTO.ShipmentDTOs;
using LogisticsManagementSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LogisticsManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly ShipmentService _shipmentService;
        private readonly CustomerService _customerService;
        public ShipmentController(ShipmentService shipmentService, CustomerService customerService)
        {
            _shipmentService = shipmentService;
            _customerService = customerService;
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
                    Status = shipemnt.Status.Value
                };

                return Ok(shipmentDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing the request.", Error = ex.Message });
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
                    Status = shipemnt.Status.Value
                };

                return Ok(shipmentDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while processing the request.", Error = ex.Message });
            }
        }
       
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShipmentCreateDTO shipmentCreateDTO)
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

                var shipment = await _shipmentService.CreateShipmentAsync(shipmentCreateDTO, customerId.Value);

                //return CreatedAtAction(nameof(GetById), new { id = shipment.ShipmentId }, shipment);
                return Ok(shipment);
            }

            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while creating the shipment." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromBody] ShipmentUpdateDTO shipmentUpdateDTO)
        {
            if (shipmentUpdateDTO == null)
                return BadRequest(new { Message = "Shipment data cannot be null." });

            if (id != shipmentUpdateDTO.ShipmentId)
                return BadRequest(new { Message = "Shipment ID in the URL does not match the Shipment ID in the request body." });

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
                return StatusCode(500, new { Message = "An error occurred while updating the shipment.", Error = ex.Message });
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
                return StatusCode(500, new { Message = "An error occurred while deleting the shipment.", Error = ex.Message });
            }
        }

    }
}
