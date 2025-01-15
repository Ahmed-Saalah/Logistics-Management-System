using LogisticsManagementSystem.DTO.ShipmentDTOs;
using LogisticsManagementSystem.Models;
using LogisticsManagementSystem.Repository;
using Stripe;

namespace LogisticsManagementSystem.Services
{
    public class ShipmentService
    {
        private readonly StripePaymentService _stripePaymentService;
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IShipmentMethodRepository _shipmentMethodRepository;

        public ShipmentService(IShipmentRepository shipmentRepository, IPaymentRepository paymentRepository, IShipmentMethodRepository shipmentMethodRepository, StripePaymentService stripePaymentService)
        {
            _shipmentRepository = shipmentRepository;
            _paymentRepository = paymentRepository;
            _shipmentMethodRepository = shipmentMethodRepository;
            _stripePaymentService = stripePaymentService;
        }

        public async Task<Shipment> CreateShipmentAsync(ShipmentCreateDTO shipmentCreateDTO, int customerId)
        {
            ShipmentMethod shipmentMethod = null;

            if (shipmentCreateDTO.ShipmentMethodId.HasValue)
            {
                shipmentMethod = await _shipmentMethodRepository.GetAsync(sm => sm.ShipmentMethodID == shipmentCreateDTO.ShipmentMethodId);
            }

            if (shipmentMethod == null)
            {
                shipmentMethod = await _shipmentMethodRepository.GetShipmentMethodByNameAsync("Standard");
            }

            if (shipmentMethod == null)
            {
                throw new Exception("Unable to find a valid ShipmentMethod.");
            }

            if (shipmentMethod == null)
            {
                throw new Exception("Unable to find a valid ShipmentMethod.");
            }

            try
            {
                var shipment = new Shipment
                {
                    ShipperName = shipmentCreateDTO.ShipperName,
                    ShipperEmail = shipmentCreateDTO.ShipperEmail,
                    ShipperPhone = shipmentCreateDTO.ShipperPhone,
                    ShipperCountry = shipmentCreateDTO.ShipperCountry,
                    ShipperCity = shipmentCreateDTO.ShipperCity,
                    ShipperStreet = shipmentCreateDTO.ShipperStreet,
                    ReceiverName = shipmentCreateDTO.ReceiverName,
                    ReceiverEmail = shipmentCreateDTO.ReceiverEmail,
                    ReceiverPhone = shipmentCreateDTO.ReceiverPhone,
                    ReceiverCountry = shipmentCreateDTO.ReceiverCountry,
                    ReceiverCity = shipmentCreateDTO.ReceiverCity,
                    ReceiverStreet = shipmentCreateDTO.ReceiverStreet,
                    Quantity = shipmentCreateDTO.Quantity,
                    Weight = shipmentCreateDTO.Weight,
                    Description = shipmentCreateDTO.Description,
                    Status = shipmentCreateDTO.Status,
                    CustomerId = customerId,
                    CreatedAt = DateTime.UtcNow,
                    ShipmentMethod = shipmentMethod
                };

                var createdShipment =  await _shipmentRepository.AddAsync(shipment); 
                
                return createdShipment;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Shipment> GetByIdAsync(int id)
        {
            return await _shipmentRepository.GetByIdAsync(id);
        }

        public async Task<Shipment> GetByTrackingNumber(string trackingNumber)
        {
            return await _shipmentRepository.GetShipmentByTrackingNumberAsync(trackingNumber);
        }

        public async Task UpdateShipmentAsync(int id, ShipmentUpdateDTO shipment)
        {
            var existingShipment = await _shipmentRepository.GetByIdAsync(id);

            if (existingShipment == null)
                throw new ArgumentException($"Shipment with ID {id} not found.");

            existingShipment.ShipperCountry = shipment.ShipperCountry;
            existingShipment.ShipperCity = shipment.ShipperCity;
            existingShipment.ShipperStreet = shipment.ShipperStreet;
            existingShipment.ShipperPhone = shipment.ShipperPhone;

            existingShipment.ReceiverCountry = shipment.ReceiverCountry;
            existingShipment.ReceiverCity = shipment.ReceiverCity;
            existingShipment.ReceiverStreet = shipment.ReceiverStreet;
            existingShipment.ReceiverPhone = shipment.ReceiverPhone;

            await _shipmentRepository.UpdateAsync(existingShipment);
        }

        public async Task DeleteAsync(int id)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(id);
            if (shipment != null)
            {
                await _shipmentRepository.DeleteAsync(id);
            }
            else
            {
                throw new ArgumentException("Shipment not found.");
            }
        }

    
        public async Task Update(Shipment shipment)
        {
            var existingShipment = await _shipmentRepository.GetByIdAsync(shipment.ShipmentId);

            if (existingShipment == null)
                throw new ArgumentException($"Shipment with ID {shipment.ShipmentId} not found.");

            await _shipmentRepository.UpdateAsync(existingShipment);
        }
    }
}
