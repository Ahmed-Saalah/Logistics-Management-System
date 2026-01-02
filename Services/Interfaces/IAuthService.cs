using LogisticsManagementSystem.DTOs;
using LogisticsManagementSystem.DTOs.IdentityDTOs;

namespace LogisticsManagementSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse> Register(RegisterDTO user);
        Task<LoginResponse> Login(LoginDTO user);
        Task<LoginResponse> ReviveToken(string refreshToken);
    }
}
