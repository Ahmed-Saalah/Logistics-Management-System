namespace LogisticsManagementSystem.DTOs.PaymentDTOs
{
    public class PaymentInitiationResponse
    {
        public int PaymentId { get; set; }
        public string CheckoutUrl { get; set; }
        public decimal Amount { get; set; }
    }
}
