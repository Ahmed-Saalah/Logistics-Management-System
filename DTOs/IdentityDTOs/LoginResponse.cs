namespace Logex.API.Dtos.IdentityDtos
{
    public record LoginResponse(
        bool Success = false,
        string Message = null!,
        string Token = null!,
        string RefreshToken = null!
    );
}
