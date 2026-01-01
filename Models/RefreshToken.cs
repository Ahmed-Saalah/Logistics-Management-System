namespace LogisticsManagementSystem.Models
{
    public class RefreshToken
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int UserId { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}
