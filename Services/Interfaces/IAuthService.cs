using LogisticsManagementSystem.DTOs.IdentityDTOs;
using LogisticsManagementSystem.DTOs.Responses;

namespace LogisticsManagementSystem.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse> Register(RegisterDTO user);
        Task<LoginResponse> Login(LoginDTO user);
        Task<LoginResponse> ReviveToken(string refreshToken);
    }
}
