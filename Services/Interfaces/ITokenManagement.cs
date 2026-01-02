using System.Security.Claims;

namespace Logex.API.Services.Interfaces
{
    public interface ITokenManagement
    {
        string GetRefreshToken();
        List<Claim> GetUserClaimsFromToken(string token);
        Task<bool> ValidateRefreshToken(string refreshToken);
        Task<int> GetUserIdByRefreshToken(string refreshToken);
        Task<int> AddRefreshToken(int userId, string refreshToken);
        Task<int> UpdateRefreshToken(string refreshToken);
        string GenerateToken(List<Claim> claims);
    }
}
