namespace LogisticsManagementSystem.DTO.PaymentDTOs
{
    public class PaymentRequestDTO
    {
        public decimal Amount { get; set; }
        public string CardNumber { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }
        public string CVC { get; set; }

        public int ShipmentId {  get; set; }
    }
}
